using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using WebAppParser.Controllers;
using WebAppParser.Models;

namespace WebAppParser.Database
{
    public class MongoDb
    {

        public static async void MongoConnect(Object property)
        {    
            var client = new MongoClient("mongodb+srv://kamil:kamil@webapp-5g6b3.mongodb.net/test?retryWrites=true");
            var mongoDatabase = client.GetDatabase("Property");
            var collection = mongoDatabase.GetCollection<Property>("Properties");
            var elem = property as Property;

            MongoFileManager mongoFileManager = new MongoFileManager(mongoDatabase);

            var gridFs = new GridFSBucket(mongoDatabase);
            
            var fileIds = mongoFileManager.UploadFile(gridFs);

            elem.ImageIds = fileIds;
            List<byte[]> imageByte = mongoFileManager.DownloadFile(gridFs, fileIds);

            elem.Image = new List<String>();
            foreach (byte[] img in imageByte)
            {
                elem.Image.Add(Convert.ToBase64String(img));
            }

            elem._id = ObjectId.GenerateNewId(DateTime.Now);

            //Check how work insertone and insertoneasync - first element in collection is saved, but next aren't
            //in insertone - elements are saved but there is an error -> No write concern mode named 'majorityy' found in replica set configuration”
            await collection.InsertOneAsync(elem);
        }
    }
}
