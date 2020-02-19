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
    public class MemberManager
    {
        
        public string RemoveReferences(int id)
        {
            ResultHelper _resultHelper = new ResultHelper();
            using (var db = new nasccoEntities())
            {
                using (DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {
                        var record = (from x in db.references
                                      where x.id == id
                                      select x).FirstOrDefault();
                        db.references.Remove(record);
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
        public string RemoveSpouse(int id)
        {
            ResultHelper _resultHelper = new ResultHelper();
            using (var db = new nasccoEntities())
            {
                using (DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {                        
                        var record = (from x in db.spouses
                                      where x.id == id
                                      select x).FirstOrDefault();
                        db.spouses.Remove(record);
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
        
        
        public string UpdateSpouse(SpouseModel model)
        {
            ResultHelper _resultHelper = new ResultHelper();
            using (var db = new nasccoEntities())
            {
                try
                {
                    var data = db.spouses.FirstOrDefault(x => x.id == model.SpouseId);

                    data.lastname = model.SpouseLastName;
                    data.firstname = model.SpouseFirstName;
                    data.middlename = model.SpouseMiddleName;
                    data.date_of_birth = model.SpouseDateOfBirth;
                    data.occupation = model.SpouseOccupation;
                    data.employer = model.SpouseEmployer;
                    data.employer_address = model.SpouseEmployerAddress;
                    data.employer_contact = model.SpouseEmployerContact;
                    data.monthly_income = model.SpouseMonthlyIncome;
                    data.contact_numbers = model.SpouseContactNumber;
                    data.employment_status = model.SpouseEmploymentStatus;
                    db.SaveChanges();
                    return _resultHelper.Success();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public string UpdateReferences(ReferencesModel model)
        {
            ResultHelper _resultHelper = new ResultHelper();
            using (var db = new nasccoEntities())
            {
                try
                {
                    var data = db.references.FirstOrDefault(x => x.id == model.ReferencesId);
                    data.full_name = model.ReferencesFullName;
                    data.relation = model.ReferencesRelation;
                    data.address = model.ReferencesAddress;
                    data.contact_number = model.ReferencesContactNumber;
                    db.SaveChanges();
                    return _resultHelper.Success();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        public string SaveReferences(ReferencesModel model)
        {
            ResultHelper _resultHelper = new ResultHelper();
            using (var db = new nasccoEntities())
            {
                using (DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {
                        var data = db.references.Create();
                        data.full_name = model.ReferencesFullName;
                        data.relation = model.ReferencesRelation;
                        data.address = model.ReferencesAddress;
                        data.contact_number = model.ReferencesContactNumber;                        
                        data.member_id = model.ReferencesMemberId;
                        data.created_by_user_id = model.ReferencesCreatedByUserId;
                        data.date_created = DateTime.Now;

                        db.references.Add(data);
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
        public string SaveSpouse(SpouseModel model)
        {
            ResultHelper _resultHelper = new ResultHelper();
            using (var db = new nasccoEntities())
            {
                using (DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {
                        var data = db.spouses.Create();
                        data.lastname = model.SpouseLastName;
                        data.firstname = model.SpouseFirstName;
                        data.middlename = model.SpouseMiddleName;
                        data.date_of_birth = model.SpouseDateOfBirth;
                        data.occupation = model.SpouseOccupation;
                        data.employer = model.SpouseEmployer;
                        data.employer_address = model.SpouseEmployerAddress;
                        data.employer_contact = model.SpouseEmployerContact;
                        data.monthly_income = model.SpouseMonthlyIncome;
                        data.contact_numbers = model.SpouseContactNumber;
                        data.employment_status = model.SpouseEmploymentStatus;
                        data.member_id = model.SpouseMemberId;
                        data.created_by_user_id = model.SpouseCreatedByUserId;
                        data.date_started = DateTime.Now;
                        db.spouses.Add(data);
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

        public string SaveMember(MemberModel model)
        {
            ResultHelper _resultHelper = new ResultHelper();
            using (var db = new nasccoEntities())
            {
                using (DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {
                        var data = db.members.Create();
                        data.pmes_certificate_number = model.PmesCertificateNumber;
                        data.date_of_application = model.DateOfApplication;
                        data.lastname = model.LastName;
                        data.firstname = model.LastName;
                        data.middlename = model.MiddleName;
                        data.date_of_birth = model.DateOfBirth;
                        data.place_of_birth = model.PlaceOfBirth;
                        data.height = model.Heigth;
                        data.weight = model.Weight;
                        data.tin = model.Tin;
                        data.sss_number = model.SssNumber;
                        data.others_id = model.OthersId;
                        data.weight = model.Weight;
                        data.tin = model.Tin;
                        data.highest_education = model.HighestEducation;
                        data.course = model.Course;
                        data.present_address = model.PresentAddress;
                        data.address_status = model.AddressStatus;
                        data.provincial_address = model.ProvincialAddress;
                        data.present_address_lenght_of_time = model.PresentAddressLengthOfTime;
                        data.contact_numbers = model.ContactNumbers;
                        data.email_address = model.EmailAddress;
                        data.statuses_id = model.StatusesId;
                        data.employee_id = model.EmployeeId;
                        data.created_by_user_id = model.CreatedByUserId;


                        db.members.Add(data);
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

        public string Update(MemberModel model)
        {
            ResultHelper _resultHelper = new ResultHelper();
            using (var db = new nasccoEntities())
            {
                try
                {
                    var data = db.members.FirstOrDefault(x => x.id == model.MemberId);                   
                    data.pmes_certificate_number = model.PmesCertificateNumber;
                    data.date_of_application = model.DateOfApplication;
                    data.lastname = model.LastName;
                    data.firstname = model.FirstName;
                    data.middlename = model.MiddleName;
                    data.date_of_birth = model.DateOfBirth;
                    data.place_of_birth = model.PlaceOfBirth;
                    data.height = model.Heigth;
                    data.weight = model.Weight;
                    data.tin = model.Tin;
                    data.sss_number = model.SssNumber;
                    data.others_id = model.OthersId;
                    data.weight = model.Weight;
                    data.tin = model.Tin;
                    data.highest_education = model.HighestEducation;
                    data.course = model.Course;
                    data.present_address = model.PresentAddress;
                    data.address_status = model.AddressStatus;
                    data.provincial_address = model.ProvincialAddress;
                    data.present_address_lenght_of_time = model.PresentAddressLengthOfTime;
                    data.contact_numbers = model.ContactNumbers;
                    data.email_address = model.EmailAddress;
                    data.statuses_id = model.StatusesId;
                    data.employee_id = model.EmployeeId;                                   
                    db.SaveChanges();
                    return _resultHelper.Success();                    
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public List<MemberModel> GetMemberList()
        {
            nasccoEntities db = new nasccoEntities();
            List<MemberModel> list = new List<MemberModel>();
            var record = (from c in db.members
                          select new
                          {
                              c.id,
                              c.pmes_certificate_number,
                              c.date_of_application,
                              c.lastname,
                              c.firstname,
                              c.middlename,
                              c.date_of_birth,
                              c.place_of_birth,
                              c.height,
                              c.weight,
                              c.tin,
                              c.sss_number, 
                              c.others_id,
                              c.highest_education,
                              c.course,
                              c.present_address,
                              c.address_status,
                              c.provincial_address,
                              c.present_address_lenght_of_time,
                              c.contact_numbers,
                              c.email_address,
                              c.statuses_id,
                              c.employee_id
                          }).AsNoTracking().ToList();

            foreach (var c in record)
            {
                list.Add(new MemberModel
                {
                    MemberId = c.id,
                    PmesCertificateNumber = c.pmes_certificate_number,
                    DateOfApplication = c.date_of_application,
                    LastName = c.lastname,
                    FirstName = c.firstname,
                    MiddleName = c.middlename,
                    DateOfBirth = c.date_of_birth,
                    PlaceOfBirth = c.place_of_birth,
                    Heigth = c.height,
                    Weight = c.weight,
                    Tin = c.tin,
                    SssNumber = c.sss_number,
                    OthersId = c.others_id,
                    HighestEducation = c.highest_education,
                    Course = c.course,
                    PresentAddress = c.present_address,
                    AddressStatus = c.address_status,
                    ProvincialAddress = c.address_status,
                    ContactNumbers = c.contact_numbers,
                    EmailAddress = c.email_address,
                    StatusesId = c.statuses_id,
                    EmployeeId = c.employee_id,
                    FullName = c.firstname + " "+ c.lastname
                });
            }
            return list;
        }

        public List<EmploymentModel> GetEmploymentList(int memberId)
        {
            nasccoEntities db = new nasccoEntities();
            List<EmploymentModel> list = new List<EmploymentModel>();
            var record = (from c in db.employments
                          where c.member_id == memberId
                          select new
                          {
                              c.id,
                              c.position,
                              c.date_hired,
                              c.employer,
                              c.employer_address,
                              c.contact_numbers,
                              c.monthly_income,
                              c.member_id,
                              member_name = c.member.firstname +" "+c.member.lastname
                          }).AsNoTracking().ToList();

            foreach (var c in record)
            {
                list.Add(new EmploymentModel
                {
                    EmploymentId = c.id,
                    EmploymentPosition = c.position,
                    EmploymentDateHired = c.date_hired,
                    EmploymentEmployer = c.employer,
                    EmploymentEmployerAddress = c.employer_address,
                    EmploymentContactNumber = c.contact_numbers,
                    EmploymentMonthlyIncome = c.monthly_income,
                    EmploymentMemberId = c.member_id,
                    EmploymentMemberName = c.member_name
                });
            }
            return list;
        }

        public List<ReferencesModel> ReferencesList(int memberId)
        {
            nasccoEntities db = new nasccoEntities();
            List<ReferencesModel> list = new List<ReferencesModel>();
            var record = (from c in db.references
                          where c.member_id == memberId
                          select new
                          {
                              c.id,
                              c.full_name,
                              c.address,
                              c.contact_number,
                              c.relation,
                              c.member_id,
                              member_name = c.member.firstname + " " + c.member.lastname
                          }).AsNoTracking().ToList();

            foreach (var c in record)
            {
                list.Add(new ReferencesModel
                {
                    ReferencesId = c.id,
                    ReferencesFullName = c.full_name,
                    ReferencesAddress = c.address,
                    ReferencesContactNumber = c.contact_number,
                    ReferencesRelation = c.relation,
                    ReferencesMemberId = c.member_id,
                    ReferencesMemberName = c.member_name
                });
            }
            return list;
        }

        public List<SpouseModel> SpouseList(int memberId)
        {
            nasccoEntities db = new nasccoEntities();
            List<SpouseModel> list = new List<SpouseModel>();
            var record = (from c in db.spouses
                          where c.member_id == memberId
                          select new
                          {
                              c.id,
                              c.lastname,
                              c.firstname,
                              c.middlename,
                              c.date_of_birth,
                              c.occupation,
                              c.employer,
                              c.employer_address,
                              c.employer_contact,
                              c.monthly_income,
                              c.contact_numbers,
                              c.employment_status,
                              c.date_started,
                              c.date_ended,
                              c.member_id,
                              member_name = c.member.firstname + " " + c.member.lastname,
                              spouse_name = c.firstname +" "+c.lastname
                          }).AsNoTracking().ToList();

            foreach (var c in record)
            {
                list.Add(new SpouseModel
                {
                    SpouseId = c.id,
                    SpouseLastName = c.lastname,
                    SpouseFirstName = c.firstname,
                    SpouseMiddleName = c.middlename,
                    SpouseDateOfBirth = c.date_of_birth,
                    SpouseContactNumber = c.contact_numbers,
                    SpouseOccupation = c.occupation,
                    SpouseEmployer = c.employer,
                    SpouseEmployerAddress = c.employer_address,
                    SpouseEmployerContact = c.employer_contact,
                    SpouseMonthlyIncome = c.monthly_income,
                    SpouseEmploymentStatus = c.employment_status,
                    SpouseEmploymentDateStarted = c.date_started,
                    SpouseEmploymentDateEnded = c.date_ended,
                    SpouseMemberId = c.member_id,
                    SpouseFullName = c.spouse_name,
                    SpouseMemberFullName = c.member_name
                });
            }
            return list;
        }

        
        public ReferencesModel GetReferencesDetail(int id)
        {
            nasccoEntities db = new nasccoEntities();
            ReferencesModel model = new ReferencesModel();
            var c = db.references.FirstOrDefault(x => x.id == id);
            if (c != null)
            {
                model.ReferencesId = c.id;
                model.ReferencesFullName = c.full_name;
                model.ReferencesRelation = c.relation;
                model.ReferencesAddress = c.address;
                model.ReferencesContactNumber = c.contact_number;
            }
            return model;
        }
        public SpouseModel GetSpouseDetail(int id)
        {
            nasccoEntities db = new nasccoEntities();
            SpouseModel model = new SpouseModel();
            var c = db.spouses.FirstOrDefault(x => x.id == id);
            if (c != null)
            {
                model.SpouseId = c.id;
                model.SpouseLastName = c.lastname;
                model.SpouseFirstName = c.firstname;
                model.SpouseMiddleName = c.middlename;
                model.SpouseDateOfBirth = c.date_of_birth;
                model.SpouseOccupation = c.occupation;
                model.SpouseEmployer = c.employer;
                model.SpouseEmployerAddress = c.employer_address;
                model.SpouseEmployerContact = c.employer_contact;
                model.SpouseMonthlyIncome = c.monthly_income;
                model.SpouseContactNumber = c.contact_numbers;
                model.SpouseEmploymentStatus = c.employment_status;
                model.SpouseMemberId = c.member_id;
            }
            return model;
        }

        public MemberModel GetMemberDetail(int id)
        {
            nasccoEntities db = new nasccoEntities();
            MemberModel model = new MemberModel();
            var c = db.members.FirstOrDefault(x => x.id == id);
            if (c != null)
            {
                model.MemberId = c.id;
                model.PmesCertificateNumber = c.pmes_certificate_number;
                model.DateOfApplication = c.date_of_application;
                model.LastName = c.lastname;
                model.FirstName = c.firstname;
                model.MiddleName = c.middlename;
                model.DateOfBirth = c.date_of_birth;
                model.PlaceOfBirth = c.place_of_birth;
                model.Heigth = c.height;
                model.Weight = c.weight;
                model.Tin = c.tin;
                model.SssNumber = c.sss_number;
                model.OthersId = c.others_id;
                model.HighestEducation = c.highest_education;
                model.Course = c.course;
                model.PresentAddress = c.present_address;
                model.AddressStatus = c.address_status;
                model.ProvincialAddress = c.provincial_address;
                model.ContactNumbers = c.contact_numbers;
                model.EmailAddress = c.email_address;
                model.StatusesId = c.statuses_id;
                model.EmployeeId = c.employee_id;
                model.FullName = c.firstname + " " + c.lastname;
                model.PresentAddressLengthOfTime = c.present_address_lenght_of_time;
            }
            return model;
        }
    }
}