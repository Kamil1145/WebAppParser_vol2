using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using System.Collections.Generic;
using MongoDB.Driver.GridFS;
using System.Threading.Tasks;
using System;
using WebAppParser.Helper;

namespace WebAppParser.Controllers
{
    public class MongoFileManager
    {
        private IMongoDatabase _imongoDatabase;
        public MongoFileManager(IMongoDatabase mongoDatabase)
        {
            _imongoDatabase = mongoDatabase; 
        }   


        public List<ObjectId> UploadFile(GridFSBucket fs)
        {
            string path = @"G:\Projekty\WebAppParser\Content\images\";
            List<string> files = Utils.FilesInFolder(path);
            List<ObjectId> objectIds = new List<ObjectId>();
            foreach (var item in files)
            {
                using (var s = File.OpenRead(path+item))
                {
                    var t = Task.Run<ObjectId>(() => 
                    {
                        return fs.UploadFromStream(item, s);
                    });

                    objectIds.Add(t.Result);
                }
            }
            return objectIds;
        }

        
        public List<byte[]> DownloadFile(GridFSBucket fs, List<ObjectId> id)
        {
            string path = @"G:\Projekty\WebAppParser\Content\images\";
            List<string> files = Utils.FilesInFolder(path);
            List<byte[]> result = new List<byte[]>();
            int counter = 0;
            foreach (string file in files)
            {
                var t = fs.DownloadAsBytesByNameAsync(file);
                Task.WaitAll(t);
                var bytes = t.Result;
                var x = fs.DownloadAsBytesAsync(id[counter++]);
                Task.WaitAll(x);
                result.Add(x.Result);
            }

            return result;

        }
    }
}
