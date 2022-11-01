using Microsoft.EntityFrameworkCore;
using ProiectulFinal.Data;
using System.Diagnostics.Metrics;
using ProiectulFinal.Models;
using ProiectulFinal.Models.DBObjects;

namespace ProiectulFinal.Models.Repository
{
    public class UserRepository
    {
        private readonly ProjectContext _DBContext;
        public UserRepository(ProjectContext dBContext)
        {
            _DBContext = dBContext;
        }
        private UserModel MapDBObjectToModel(User dbobject)
        {
            var model = new UserModel();
            if (dbobject != null)
            {
                model.IdUser = dbobject.IdUser;
                model.Name = dbobject.Name;
                model.YearOfBirth = dbobject.YearOfBirth;
                model.NumberOfPosts = dbobject.NumberOfPosts;
                model.FirstRegistered = dbobject.FirstRegistered;
                model.Id = dbobject.Id;
            }
            return model;
        }

        private User MapModelToDBObject(UserModel model)
        {
            var dbobject = new User();
            if (dbobject != null)
            {
                dbobject.IdUser = model.IdUser;
                dbobject.Name = model.Name;
                dbobject.YearOfBirth = model.YearOfBirth;
                dbobject.NumberOfPosts = model.NumberOfPosts;
                dbobject.FirstRegistered = model.FirstRegistered;
                dbobject.Id = model.Id;
            }
            return dbobject;
        }

        public List<UserModel> GetAllUsers()
        {
            var list = new List<UserModel>();
            foreach (var dbobject in _DBContext.Users)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public UserModel GetUserByID(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Users.FirstOrDefault(x => x.IdUser == id));
        }

        public void InsertUser(UserModel model)
        {
            model.IdUser = Guid.NewGuid();
            _DBContext.Users.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateUser(UserModel model)
        {
            var dbobject = _DBContext.Users.FirstOrDefault(x => x.IdUser == model.IdUser);
            if (dbobject != null)
            {
                dbobject.IdUser = model.IdUser;
                dbobject.Name = model.Name;
                dbobject.YearOfBirth = model.YearOfBirth;
                dbobject.NumberOfPosts = model.NumberOfPosts;
                dbobject.FirstRegistered = model.FirstRegistered;
                dbobject.Id = model.Id;
                _DBContext.SaveChanges();
            }


        }

        public void DeleteUser(UserModel model)
        {
            var dbobject = _DBContext.Users.FirstOrDefault(x => x.IdUser == model.IdUser);
            if (dbobject != null)
            {
                _DBContext.Users.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
