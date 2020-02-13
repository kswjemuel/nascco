using CoopSystemWebApp.DB;
using CoopSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Manager
{
    public class CommonManager
    {
        readonly nasccoEntities db = new nasccoEntities();


        public List<RoleModel> GetRole()
        {
            var list = new List<RoleModel>();
            var result = (from c in db.roles                          
                          select new
                          {
                              c.id,
                              description = c.description
                          });


            if (result != null && result.Any())
            {
                foreach (var data in result)
                {
                    list.Add(new RoleModel
                    {
                        RoleId = data.id,
                        RoleDescription = data.description
                    });
                }
            }
            return list;
        }


        public List<MemberModel> GetMember()
        {
            var list = new List<MemberModel>();

            var result = (from c in db.members
                          where c.statuses_id != 2 //Not InActive
                          select new
                          {
                              c.id,
                              full_name = c.employee_id + ":" + c.firstname + " " + c.lastname
                          });

            if (result != null && result.Any())
            {
                foreach (var data in result)
                {
                    list.Add(new MemberModel
                    {
                        MemberId = data.id,
                        FullName = data.full_name
                    });
                }
            }
            return list;
        }

        public List<MemberModel> GetMemberEdit()
        {
            var list = new List<MemberModel>();

            var userIds = db.users.Select(x => x.member_id).ToArray();  
            var result = db.members.Where(p => !userIds.Contains(p.id)).ToList();

            if (result != null && result.Any())
            {
                foreach (var data in result)
                {
                    list.Add(new MemberModel
                    {
                        MemberId= data.id,
                        FullName = data.employee_id + ":" + data.firstname + " " + data.lastname
                    });
                }
            }
            return list;
        }

        public List<StatusModel> GetStatus(int exceptID)
        {

            var list = new List<StatusModel>();
            var result = (from c in db.statuses
                          where c.id != exceptID
                          select new
                          {
                              c.id,
                              c.description
                          });
            

            if (result != null && result.Any())
            {
                foreach (var item in result)
                {
                    list.Add(new StatusModel
                    {
                        StatusesId = item.id,
                        StatusDescription = item.description
                    });
                }
            }
            return list;
        }
    }
}