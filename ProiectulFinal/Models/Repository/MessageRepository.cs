﻿using Microsoft.EntityFrameworkCore;
using ProiectulFinal.Data;
using System.Diagnostics.Metrics;
using ProiectulFinal.Models;
using ProiectulFinal.Models.DBObjects;

namespace ProiectulFinal.Models.Repository
{
    public class MessageRepository
    {
        private readonly ProjectContext _DBContext;
        public MessageRepository(ProjectContext dBContext)
        {
            _DBContext = dBContext;
        }
        private MessageModel MapDBObjectToModel(Message dbobject)
        {
            var model = new MessageModel();
            if (dbobject != null)
            {
                model.IdMessage = dbobject.IdMessage;
                model.Text = dbobject.Text;
                model.IdUser = dbobject.IdUser;
                model.IdPost = dbobject.IdPost;
                
            }
            return model;
        }

        private Message MapModelToDBObject(MessageModel model)
        {
            var dbobject = new Message();
            if (dbobject != null)
            {
                dbobject.IdMessage = model.IdMessage;
                dbobject.Text = model.Text;
                dbobject.IdUser = model.IdUser;
                dbobject.IdPost = model.IdPost;
            }
            return dbobject;
        }

        public List<MessageModel> GetAllMessages()
        {
            var list = new List<MessageModel>();
            foreach (var dbobject in _DBContext.Messages)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public MessageModel GetMessageByID(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Messages.FirstOrDefault(x => x.IdMessage == id));
        }

        public void InsertMessage(MessageModel model)
        {
            model.IdMessage = Guid.NewGuid();
            _DBContext.Messages.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateMessage(MessageModel model)
        {
            var dbobject = _DBContext.Messages.FirstOrDefault(x => x.IdMessage == model.IdMessage);
            if (dbobject != null)
            {
                dbobject.IdMessage= model.IdMessage;
                dbobject.Text = model.Text;
                dbobject.IdUser = model.IdUser;
                dbobject.IdPost = model.IdPost;
                _DBContext.SaveChanges();
            }


        }

        public void DeleteMessage(MessageModel model)
        {
            var dbobject = _DBContext.Messages.FirstOrDefault(x => x.IdMessage== model.IdMessage);
            if (dbobject != null)
            {
                _DBContext.Messages.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
