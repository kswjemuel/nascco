using CoopSystemWebApp.DB;
using CoopSystemWebApp.Helper;
using CoopSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Manager
{
    public class UserManager
    {
        public string RemoveUser(int id)
        {
            ResultHelper _resultHelper = new ResultHelper();
            using (var db = new nasccoEntities())
            {
                using (DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {
                        var record = (from x in db.users
                                      where x.id == id
                                      select x).FirstOrDefault();
                        db.users.Remove(record);
                        db.SaveChanges();



                        dbTran.Commit();
                        return _resultHelper.Success();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        return ex.Message;
                    }
                }
            }
        }

        public int GetEmployeeId(int id)
        {
            int employeeId = 0;
            using (var db = new nasccoEntities())
            {
                try
                {
                    var data = db.members.FirstOrDefault(x => x.id == id);
                    employeeId = data.employee_id;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }

            return employeeId;
        }

        public string Update(UserModel model)
        {
            ResultHelper _resultHelper = new ResultHelper();
            using (var db = new nasccoEntities())
            {
                try
                {
                    var data = db.users.FirstOrDefault(x => x.id == model.UserId);
                    data.member_id = model.UserMemberId;
                    data.roles_id = model.RolesId;
                    data.statuses_id = model.UserStatusesId;
                    data.username = model.Username;                    
                    db.SaveChanges();
                    return _resultHelper.Success();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public string Save(UserModel model)
        {
            ResultHelper _resultHelper = new ResultHelper();
            using (var db = new nasccoEntities())
            {
                using (DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {
                        var data = db.users.Create();
                        data.member_id = model.UserMemberId;
                        data.roles_id = model.RolesId;
                        data.statuses_id = model.UserStatusesId;
                        data.username = model.Username;
                        data.password = EncryptDecryptString.Encrypt(model.Password);
                        data.date_created = DateTime.Now;
                        data.created_by_user_id = model.CreatedByUserId;
                        db.users.Add(data);
                        db.SaveChanges();

                        //Save if no issues
                        dbTran.Commit();
                        return _resultHelper.Success();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        return ex.Message;
                    }
                }
            }
        }

        public string ChangePassword(UserModel model)
        {
            ResultHelper _resultHelper = new ResultHelper();
            using (var db = new nasccoEntities())
            {
                using (DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {
                        var data = db.users.FirstOrDefault(x => x.id == model.UserId);                        
                        data.password = EncryptDecryptString.Encrypt(model.Password);                        
                        db.SaveChanges();

                        //Save if no issues
                        dbTran.Commit();
                        return _resultHelper.Success();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        return ex.Message;
                    }
                }
            }
        }

        public List<UserModel> GetUserList()
        {
            nasccoEntities db = new nasccoEntities();
            List<UserModel> list = new List<UserModel>();
            var record = (from c in db.users
                          select new
                          {
                              c.id,
                              c.member_id,
                              c.roles_id,
                              c.statuses_id,
                              c.username,
                              full_name=c.member.firstname +" "+c.member.lastname,
                              role_description = c.role.description,
                              status_description = c.status.description
                          }).AsNoTracking().ToList();

            foreach (var c in record)
            {
                list.Add(new UserModel
                {
                    UserId = c.id,
                    UserMemberId = c.member_id,
                    RolesId = c.roles_id,
                    UserStatusesId = c.statuses_id,
                    FullName = c.full_name,
                    RoleDescription = c.role_description,
                    StatusDescription = c.status_description,
                    Username = c.username
                });
            }
            return list;
        }


        public ActiveUserDataModel CheckRecord(string username, string password)
        {            
            password = EncryptDecryptString.Encrypt(password);
            using (var db = new nasccoEntities())
            {
                try
                {
                    var data = db.users.FirstOrDefault(x => x.username == username &&
                                    (x.statuses_id == 1 || x.statuses_id == 3 || x.statuses_id == 7));
                    if(data != null)
                    {
                        if(data.password == password)
                        {
                            return new ActiveUserDataModel
                            {
                                UserId = data.id,
                                FullName = data.member.firstname + " " + data.member.lastname,
                                RoleId = data.roles_id,
                                RoleName = data.role.description,
                                UserName = data.username
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                    
                }
                catch (Exception ex)
                {

                    string err = ex.Message;
                    
                }
            }

            return null;
        }

        public string CheckPassword(string username, string password)
        {
            ResultHelper _resultHelper = new ResultHelper();
            password = EncryptDecryptString.Encrypt(password);
            using (var db = new nasccoEntities())
            {
                try
                {
                    var data = db.users.FirstOrDefault(x => x.username == username &&
                                    (x.statuses_id == 1 || x.statuses_id == 3 || x.statuses_id == 7));
                    if (data != null)
                    {
                        if (data.password == password)
                        {
                            return _resultHelper.Success();
                        }
                        else
                        {
                            return "failed";
                        }
                    }

                }
                catch (Exception ex)
                {

                    string err = ex.Message;

                }
            }

            return "failed";
        }


        public UserModel GetUserDetail(int id)
        {
            nasccoEntities db = new nasccoEntities();
            UserModel model = new UserModel();
            var c = db.users.FirstOrDefault(x => x.id == id);
            if (c != null)
            {
                model.UserId = c.id;
                model.UserMemberId = c.member_id;
                model.RolesId = c.roles_id;
                model.UserStatusesId = c.statuses_id;
                model.FullName = c.member.firstname + " " + c.member.lastname;
                model.RoleDescription = c.role.description;
                model.StatusDescription = c.status.description;
                model.Username = c.username;
            }
            return model;
        }
    }
}