using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for BranchService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class BranchService : System.Web.Services.WebService
{
    DataClassesDataContext dbc = new DataClassesDataContext();

    public BranchService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";

    }


    //Payment Mode 
    public List<tbl_PaymentMode> fillPaymentModeList()
    {
        dbc = new DataClassesDataContext();
        var a = (from c in dbc.tbl_PaymentModes
                 select c).ToList();
        return a;
    }

    public int paymentmode_insert(string paymentmode, Boolean status, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_PaymentMode pm = new tbl_PaymentMode();
            pm.CreatedAt = createdat;
            pm.ModifiedAt = modifiedat;
            pm.PaymentMode = paymentmode;
            pm.Status = status;

            dbc = new DataClassesDataContext();
            dbc.tbl_PaymentModes.InsertOnSubmit(pm);
            dbc.SubmitChanges();

            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_PaymentMode> get_paymentmode_list(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var a = (from c in dbc.tbl_PaymentModes
                 where c.Id == id
                 select c).ToList();
        return a;
    }

    public int delete_paymentmode(Int64 payment_id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var a = (from c in dbc.tbl_PaymentModes
                     where c.Id == payment_id
                     select c).SingleOrDefault();

            dbc.tbl_PaymentModes.DeleteOnSubmit(a);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }

    }

    public int update_paymentmode(string paymentmode, Boolean status, DateTime createdat, DateTime modifiedat, Int64 payid)
    {
        try
        {
            tbl_PaymentMode pm = (from c in dbc.tbl_PaymentModes
                                  where c.Id == payid
                                  select c).SingleOrDefault();
            pm.CreatedAt = createdat;
            pm.ModifiedAt = modifiedat;
            pm.PaymentMode = paymentmode;
            pm.Status = status;
            dbc = new DataClassesDataContext();
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    //Expensehead 
    public int expensehead_insert(string headname, Boolean status, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_ExpenseHead eh = new tbl_ExpenseHead();
            eh.CreatedAt = createdat;
            eh.HeadName = headname;
            eh.ModifiedAt = modifiedat;
            eh.Status = status;

            dbc = new DataClassesDataContext();
            dbc.tbl_ExpenseHeads.InsertOnSubmit(eh);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_ExpenseHead> get_expenselist()
    {
        dbc = new DataClassesDataContext();
        var e = (from c in dbc.tbl_ExpenseHeads
                 select c).ToList();
        return e;

    }

    public List<tbl_ExpenseHead> get_expensebylist(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var e = (from c in dbc.tbl_ExpenseHeads
                 where c.Id == id
                 select c).ToList();
        return e;
    }

    public int delete_expense(Int64 expid)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var e = (from c in dbc.tbl_ExpenseHeads
                     where c.Id == expid
                     select c).SingleOrDefault();

            dbc.tbl_ExpenseHeads.DeleteOnSubmit(e);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_expensehead(string headname, Boolean status, DateTime createdat, DateTime modifiedat, Int64 expenseid)
    {
        try
        {
            tbl_ExpenseHead eh = (from c in dbc.tbl_ExpenseHeads
                                  where c.Id == expenseid
                                  select c).SingleOrDefault();
            eh.CreatedAt = createdat;
            eh.HeadName = headname;
            eh.ModifiedAt = modifiedat;
            eh.Status = status;

            dbc = new DataClassesDataContext();
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    //expensemaster 

    public int expensemaster_insert(DateTime expensedate, string typeofexpense, decimal amount, Int64 headid, Int64 paymentmodeid, string remark, string cancel, string reason, DateTime createdat, DateTime modifiedat, Int64 branchid)
    {
        try
        {
            tbl_ExpenseMaster em = new tbl_ExpenseMaster();
            em.Amount = amount;
            em.BranchId = branchid;
            em.Cancel_Delete = cancel;
            em.CreatedAt = createdat;
            em.ExpenseDate = expensedate;
            em.HeadId = headid;
            em.ModifiedAt = modifiedat;
            em.PaymentModeId = paymentmodeid;
            em.Reason = reason;
            em.Remark = remark;
            em.TypeOfExpense = typeofexpense;

            dbc = new DataClassesDataContext();
            dbc.tbl_ExpenseMasters.InsertOnSubmit(em);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_ExpenseMaster> get_expensemaster()
    {
        dbc = new DataClassesDataContext();
        var e = (from c in dbc.tbl_ExpenseMasters
                 select c).ToList();
        return e;
    }

    public List<tbl_ExpenseMaster> get_expensemasterbylist(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var e = (from c in dbc.tbl_ExpenseMasters
                 where c.Id == id
                 select c).ToList();
        return e;
    }

    public int delete_expensemaster(Int64 expid)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var e = (from c in dbc.tbl_ExpenseMasters
                     where c.Id == expid
                     select c).SingleOrDefault();
            dbc.tbl_ExpenseMasters.DeleteOnSubmit(e);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_expensemaster(DateTime expensedate, string typeofexpense, decimal amount, Int64 headid, Int64 paymentmodeid, string remark, string cancel, string reason, DateTime createdat, DateTime modifiedat, Int64 branchid, Int64 id)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_ExpenseMaster em = (from c in dbc.tbl_ExpenseMasters
                                    where c.Id == id
                                    select c).SingleOrDefault();
            em.Amount = amount;
            em.BranchId = branchid;
            em.Cancel_Delete = cancel;
            em.CreatedAt = createdat;
            em.ExpenseDate = expensedate;
            em.HeadId = headid;
            em.ModifiedAt = modifiedat;
            em.PaymentModeId = paymentmodeid;
            em.Reason = reason;
            em.Remark = remark;
            em.TypeOfExpense = typeofexpense;


            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    //Service Master 
    public int servicemaster_insert(string servicename, string category, Int32 duration, decimal price, string rewardpoint, string servicefor, DateTime createdat, DateTime modifiedat, Int64 branchid)
    {

        try
        {
            tbl_ServiceMaster sm = new tbl_ServiceMaster();
            sm.BranchId = branchid;
            sm.Category = category;
            sm.CreatedAt = createdat;
            sm.Duration = duration;
            sm.ModifiedAt = modifiedat;
            sm.Price = price;
            sm.RewardPoints = rewardpoint;
            sm.ServiceFor = servicefor;
            sm.ServiceName = servicename;

            dbc = new DataClassesDataContext();
            dbc.tbl_ServiceMasters.InsertOnSubmit(sm);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_ServiceMaster> get_servicemaster()
    {
        dbc = new DataClassesDataContext();
        var s = (from c in dbc.tbl_ServiceMasters
                 select c).ToList();
        return s;
    }

    public List<tbl_ServiceMaster> get_servicelistby_id(Int64 serviceid)
    {
        dbc = new DataClassesDataContext();
        var s = (from c in dbc.tbl_ServiceMasters
                 where c.Id == serviceid
                 select c).ToList();
        return s;
    }

    public int delete_servicemaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var s = (from c in dbc.tbl_ServiceMasters
                     where c.Id == id
                     select c).SingleOrDefault();

            dbc.tbl_ServiceMasters.DeleteOnSubmit(s);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_servicematser(Int64 serviceid, string servicename, string category, Int32 duration, decimal price, string rewardpoint, string servicefor, DateTime createdat, DateTime modifiedat, Int64 branchid)
    {
        try
        {

            tbl_ServiceMaster sm = (from c in dbc.tbl_ServiceMasters
                                    where c.Id == serviceid
                                    select c).SingleOrDefault();
            sm.BranchId = branchid;
            sm.Category = category;
            sm.CreatedAt = createdat;
            sm.Duration = duration;
            sm.ModifiedAt = modifiedat;
            sm.Price = price;
            sm.RewardPoints = rewardpoint;
            sm.ServiceFor = servicefor;
            sm.ServiceName = servicename;

            dbc = new DataClassesDataContext();
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    //Package Master
    public int packagemaster_insert(string packagename, Int32 duration, DateTime validity, decimal price, Int64 branchid, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_PackageMaster pm = new tbl_PackageMaster();
            pm.BranchId = branchid;
            pm.CreatedAt = createdat;
            pm.Duration = duration;
            pm.ModifiedAt = modifiedat;
            pm.PackageName = packagename;
            pm.PackagePrice = price;
            pm.PackageValidity = validity;

            dbc = new DataClassesDataContext();
            dbc.tbl_PackageMasters.InsertOnSubmit(pm);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_PackageMaster> get_packagelist()
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_PackageMasters
                 select c).ToList();
        return p;
    }

    public List<tbl_PackageMaster> get_packagelistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_PackageMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_packagemaster(Int64 packageid)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_PackageMasters
                     where c.Id == packageid
                     select c).SingleOrDefault();

            dbc.tbl_PackageMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_packagemaster(Int64 id, string packagename, Int32 duration, DateTime validity, decimal price, Int64 branchid, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_PackageMaster pm = (from c in dbc.tbl_PackageMasters
                                    where c.Id == id
                                    select c).SingleOrDefault();

            pm.BranchId = branchid;
            pm.CreatedAt = createdat;
            pm.Duration = duration;
            pm.ModifiedAt = modifiedat;
            pm.PackageName = packagename;
            pm.PackagePrice = price;
            pm.PackageValidity = validity;


            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }


    //PackageDetailMaster
    public int packagedetailmaster_insert(Int64 branchid, Int64 packageid, Int64 serviceid, decimal quantity, decimal price, string category, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_PackageDetailMaster pdm = new tbl_PackageDetailMaster();

            pdm.BranchId = branchid;
            pdm.Category = category;
            pdm.CreatedAt = createdat;
            pdm.ModifiedAt = modifiedat;
            pdm.PackageId = packageid;
            pdm.Price = price;
            pdm.Quantity = quantity;
            pdm.ServiceId = serviceid;


            dbc = new DataClassesDataContext();
            dbc.tbl_PackageDetailMasters.InsertOnSubmit(pdm);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_PackageDetailMaster> get_packagedetaillist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_PackageDetailMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_PackageDetailMaster> get_packagedetaillistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_PackageDetailMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_packagedetailmaster(Int64 packageid)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_PackageDetailMasters
                     where c.Id == packageid
                     select c).SingleOrDefault();

            dbc.tbl_PackageDetailMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_packagedetailmaster(Int64 id, Int64 branchid, Int64 packageid, Int64 serviceid, decimal quantity, decimal price, string category, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_PackageDetailMaster pdm = (from c in dbc.tbl_PackageDetailMasters
                                           where c.Id == id
                                           select c).SingleOrDefault();


            pdm.BranchId = branchid;
            pdm.Category = category;
            pdm.CreatedAt = createdat;
            pdm.ModifiedAt = modifiedat;
            pdm.PackageId = packageid;
            pdm.Price = price;
            pdm.Quantity = quantity;
            pdm.ServiceId = serviceid;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    //CouponMaster
    public int couponmaster_insert(Int64 branchid, string couponcode, decimal discount, string discounttype, decimal minbillingamount, decimal maxdiscountamount, Int32 couponperuser, DateTime validity, decimal rewardpoint, DateTime createdat, DateTime modifiedat)
    {
        try
        {

            tbl_CouponMaster cm = new tbl_CouponMaster();

            cm.BranchId = branchid;
            cm.CouponCode = couponcode;
            cm.CouponPerUser = couponperuser;
            cm.CreatedAt = createdat;
            cm.Discount = discount;
            cm.DiscountType = discounttype;
            cm.MaxDiscountAmount = maxdiscountamount;
            cm.MinimumBillingAmount = minbillingamount;
            cm.ModifiedAt = modifiedat;
            cm.RewardPoint = rewardpoint;
            cm.Validity = validity;


            dbc = new DataClassesDataContext();
            dbc.tbl_CouponMasters.InsertOnSubmit(cm);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_CouponMaster> get_couponlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_CouponMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_CouponMaster> get_couponlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_CouponMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_couponmaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_CouponMasters
                     where c.Id == id
                     select c).SingleOrDefault();

            dbc.tbl_CouponMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_couponmaster(Int64 id, Int64 branchid, string couponcode, decimal discount, string discounttype, decimal minbillingamount, decimal maxdiscountamount, Int32 couponperuser, DateTime validity, decimal rewardpoint, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_CouponMaster cm = (from c in dbc.tbl_CouponMasters
                                   where c.Id == id
                                   select c).SingleOrDefault();

            cm.BranchId = branchid;
            cm.CouponCode = couponcode;
            cm.CouponPerUser = couponperuser;
            cm.CreatedAt = createdat;
            cm.Discount = discount;
            cm.DiscountType = discounttype;
            cm.MaxDiscountAmount = maxdiscountamount;
            cm.MinimumBillingAmount = minbillingamount;
            cm.ModifiedAt = modifiedat;
            cm.RewardPoint = rewardpoint;
            cm.Validity = validity;


            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }


    //ServiceProviderMasetr
    public int serviceprovidermaster_insert(string providename, decimal servicecomission, decimal productcomission, DateTime dateofbirth, DateTime whs, DateTime whe, decimal monthlysalary, string serviceprovidertype, string contact, string email, string emergencycontact, string energencycontactperson, string address, string username, string password, string gender, DateTime dateofjoining, string idproof, string serviceproviderphoto, Boolean status, Int64 branchid, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_ServiceProviderMaster sm = new tbl_ServiceProviderMaster();

            sm.Address = address;
            sm.BranchId = branchid;
            sm.ContactNumber = contact;
            sm.CreatedAt = createdat;
            sm.DateOfBirth = dateofbirth;
            sm.DateOfJoinning = dateofjoining;
            sm.Email = email;
            sm.EmergencyContactNo = emergencycontact;
            sm.EmergencyContactPerson = energencycontactperson;
            sm.Gender = gender;
            sm.IdProofPhoto = idproof;
            sm.ModifiedAt = modifiedat;
            sm.MonthlySalary = monthlysalary;
            sm.Password = password;
            sm.ProductComission = productcomission;
            sm.ProviderName = providename;
            sm.ServiceComission = servicecomission;
            sm.ServiceProviderPhoto = serviceproviderphoto;
            sm.ServiceProviderType = serviceprovidertype;
            sm.Status = status;
            sm.Username = username;
            sm.WorkingHourEnd = whe;
            sm.WorkingHourStart = whs;

            dbc = new DataClassesDataContext();
            dbc.tbl_ServiceProviderMasters.InsertOnSubmit(sm);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_ServiceProviderMaster> get_serviceprovidemasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_ServiceProviderMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_ServiceProviderMaster> get_serviceprovidemasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_ServiceProviderMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_serviceprovidermaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_ServiceProviderMasters
                     where c.Id == id
                     select c).SingleOrDefault();

            dbc.tbl_ServiceProviderMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_serviceprovidermaster(Int64 id, string providename, decimal servicecomission, decimal productcomission, DateTime dateofbirth, DateTime whs, DateTime whe, decimal monthlysalary, string serviceprovidertype, string contact, string email, string emergencycontact, string energencycontactperson, string address, string username, string password, string gender, DateTime dateofjoining, string idproof, string serviceproviderphoto, Boolean status, Int64 branchid, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_ServiceProviderMaster sm = (from c in dbc.tbl_ServiceProviderMasters
                                            where c.Id == id
                                            select c).SingleOrDefault();

            sm.Address = address;
            sm.BranchId = branchid;
            sm.ContactNumber = contact;
            sm.CreatedAt = createdat;
            sm.DateOfBirth = dateofbirth;
            sm.DateOfJoinning = dateofjoining;
            sm.Email = email;
            sm.EmergencyContactNo = emergencycontact;
            sm.EmergencyContactPerson = energencycontactperson;
            sm.Gender = gender;
            sm.IdProofPhoto = idproof;
            sm.ModifiedAt = modifiedat;
            sm.MonthlySalary = monthlysalary;
            sm.Password = password;
            sm.ProductComission = productcomission;
            sm.ProviderName = providename;
            sm.ServiceComission = servicecomission;
            sm.ServiceProviderPhoto = serviceproviderphoto;
            sm.ServiceProviderType = serviceprovidertype;
            sm.Status = status;
            sm.Username = username;
            sm.WorkingHourEnd = whe;
            sm.WorkingHourStart = whs;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    //StaffMaster
    public int staffmaster_insert(string employeename, DateTime DOB, string contactno, string email, DateTime whs, DateTime whe, decimal monthlysalary, string emergencycontact, string emergencycontactperson, string address, string username, string password, string gender, DateTime dateofjoining, string department, string idproofphoto, string usertype, string photo, Int64 branchid, Boolean status)
    {
        try
        {
            tbl_StaffMaster sm = new tbl_StaffMaster();

            sm.Address = address;
            sm.BranchId = branchid;
            sm.ContactNo = contactno;
            sm.DateOfBirth = DOB;
            sm.DateOfJoining = dateofjoining;
            sm.Department = department;
            sm.Email = email;
            sm.EmergencyContactNo = emergencycontact;
            sm.EmergencyContactPerson = emergencycontactperson;
            sm.EmployeeName = employeename;
            sm.Gender = gender;
            sm.IdProofPhoto = idproofphoto;
            sm.MonthlySalary = monthlysalary;
            sm.Password = password;
            sm.Status = status;
            sm.Username = username;
            sm.UserPhoto = photo;
            sm.UserType = usertype;
            sm.WorkingHourEnd = whe;
            sm.WorkingHourStart = whs;

            dbc = new DataClassesDataContext();
            dbc.tbl_StaffMasters.InsertOnSubmit(sm);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_StaffMaster> get_staffmasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_StaffMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_StaffMaster> get_staffmasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_StaffMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_staffmaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_StaffMasters
                     where c.Id == id
                     select c).SingleOrDefault();

            dbc.tbl_StaffMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_staffmaster(Int64 id, string employeename, DateTime DOB, string contactno, string email, DateTime whs, DateTime whe, decimal monthlysalary, string emergencycontact, string emergencycontactperson, string address, string username, string password, string gender, DateTime dateofjoining, string department, string idproofphoto, string usertype, string photo, Int64 branchid, Boolean status)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_StaffMaster sm = (from c in dbc.tbl_StaffMasters
                                  where c.Id == id
                                  select c).SingleOrDefault();

            sm.Address = address;
            sm.BranchId = branchid;
            sm.ContactNo = contactno;
            sm.DateOfBirth = DOB;
            sm.DateOfJoining = dateofjoining;
            sm.Department = department;
            sm.Email = email;
            sm.EmergencyContactNo = emergencycontact;
            sm.EmergencyContactPerson = emergencycontactperson;
            sm.EmployeeName = employeename;
            sm.Gender = gender;
            sm.IdProofPhoto = idproofphoto;
            sm.MonthlySalary = monthlysalary;
            sm.Password = password;
            sm.Status = status;
            sm.Username = username;
            sm.UserPhoto = photo;
            sm.UserType = usertype;
            sm.WorkingHourEnd = whe;
            sm.WorkingHourStart = whs;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    //MembershipMaster
    public int membershipmaster_insert(Int64 branchid, string membershiptype, decimal membershipprice, Int32 duration, decimal rewaedpointonpurchase, decimal discountonservice, decimal discountonservicetype, decimal discountonproduct, decimal discountonproducttype, decimal discountonpackage, decimal discountonpackagetype, Int32 rewardpointboost, Int32 minrewardpoint, decimal minbillamount, Boolean status, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_MembershipMaster mm = new tbl_MembershipMaster();

            mm.BranchId = branchid;
            mm.CreatedAt = createdat;
            mm.DiscountOnPackage = discountonpackage;
            mm.DiscountOnPackageType = discountonpackagetype;
            mm.DiscountOnProduct = discountonproduct;
            mm.DiscountOnProductType = discountonproducttype;
            mm.DiscountOnService = discountonservice;
            mm.DiscountOnServiceType = discountonservicetype;
            mm.Duration = duration;
            mm.MembershipPrice = membershipprice;
            mm.MembershipType = membershiptype;
            mm.MinimumBillAmount = minbillamount;
            mm.MinimumRewardPoint = minrewardpoint;
            mm.ModifiedAt = modifiedat;
            mm.RewardPointBoost = rewardpointboost;
            mm.RewardPointOnPurchase = rewaedpointonpurchase;
            mm.Status = status;

            dbc = new DataClassesDataContext();
            dbc.tbl_MembershipMasters.InsertOnSubmit(mm);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_MembershipMaster> get_membershipmasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_MembershipMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_MembershipMaster> get_membershipmasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_MembershipMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_membershipmaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_MembershipMasters
                     where c.Id == id
                     select c).SingleOrDefault();

            dbc.tbl_MembershipMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_membershipmaster(Int64 id, Int64 branchid, string membershiptype, decimal membershipprice, Int32 duration, decimal rewaedpointonpurchase, decimal discountonservice, decimal discountonservicetype, decimal discountonproduct, decimal discountonproducttype, decimal discountonpackage, decimal discountonpackagetype, Int32 rewardpointboost, Int32 minrewardpoint, decimal minbillamount, Boolean status, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_MembershipMaster mm = (from c in dbc.tbl_MembershipMasters
                                       where c.Id == id
                                       select c).SingleOrDefault();

            mm.BranchId = branchid;
            mm.CreatedAt = createdat;
            mm.DiscountOnPackage = discountonpackage;
            mm.DiscountOnPackageType = discountonpackagetype;
            mm.DiscountOnProduct = discountonproduct;
            mm.DiscountOnProductType = discountonproducttype;
            mm.DiscountOnService = discountonservice;
            mm.DiscountOnServiceType = discountonservicetype;
            mm.Duration = duration;
            mm.MembershipPrice = membershipprice;
            mm.MembershipType = membershiptype;
            mm.MinimumBillAmount = minbillamount;
            mm.MinimumRewardPoint = minrewardpoint;
            mm.ModifiedAt = modifiedat;
            mm.RewardPointBoost = rewardpointboost;
            mm.RewardPointOnPurchase = rewaedpointonpurchase;
            mm.Status = status;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }


    //InquiryMaster

    public int inquirymaster_insert(Int64 branchid, string contact, string clientname, string email, string address, string inquiryfor, string inquirytype, string response, DateTime datetofollow, string sourceofinquiry, string leadby, Boolean leadstatus, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_InquiryMaster im = new tbl_InquiryMaster();

            im.Address = address;
            im.BranchId = branchid;
            im.ClientName = clientname;
            im.ContactNo = contact;
            im.CreatedAt = createdat;
            im.DateToFollow = datetofollow;
            im.Email = email;
            im.InquiryFor = inquiryfor;
            im.InquiryType = inquirytype;
            im.LeadBy = leadby;
            im.LeadStatus = leadstatus;
            im.ModifiedAt = modifiedat;
            im.Response = response;
            im.SourceOfInquiry = sourceofinquiry;


            dbc = new DataClassesDataContext();
            dbc.tbl_InquiryMasters.InsertOnSubmit(im);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_InquiryMaster> get_inquirymasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_InquiryMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_InquiryMaster> get_inquirymasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_InquiryMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_inquirymaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_InquiryMasters
                     where c.Id == id
                     select c).SingleOrDefault();

            dbc.tbl_InquiryMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_inquirymaster(Int64 id, Int64 branchid, string contact, string clientname, string email, string address, string inquiryfor, string inquirytype, string response, DateTime datetofollow, string sourceofinquiry, string leadby, Boolean leadstatus, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_InquiryMaster im = (from c in dbc.tbl_InquiryMasters
                                    where c.Id == id
                                    select c).SingleOrDefault();
            im.Address = address;
            im.BranchId = branchid;
            im.ClientName = clientname;
            im.ContactNo = contact;
            im.CreatedAt = createdat;
            im.DateToFollow = datetofollow;
            im.Email = email;
            im.InquiryFor = inquiryfor;
            im.InquiryType = inquirytype;
            im.LeadBy = leadby;
            im.LeadStatus = leadstatus;
            im.ModifiedAt = modifiedat;
            im.Response = response;
            im.SourceOfInquiry = sourceofinquiry;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    //ClientMaster
    public int Clientmaster_insert(Int64 branchid, string clientname, string contactno, string email, string source, string assignto, string service, string gender, Boolean status)
    {
        try
        {
            tbl_ClientMaster cm = new tbl_ClientMaster();
            cm.AssignTo = assignto;
            cm.BranchId = branchid;
            cm.ClientName = clientname;
            cm.ContactNo = contactno;
            cm.Email = email;
            cm.Gender = gender;
            cm.Service = service;
            cm.Source = source;
            cm.Status = status;


            dbc = new DataClassesDataContext();
            dbc.tbl_ClientMasters.InsertOnSubmit(cm);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_ClientMaster> get_clientmasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_ClientMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_ClientMaster> get_clientmasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_ClientMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_clientmaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_ClientMasters
                     where c.Id == id
                     select c).SingleOrDefault();

            dbc.tbl_ClientMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_clientmaster(Int64 id, Int64 branchid, string clientname, string contactno, string email, string source, string assignto, string service, string gender, Boolean status)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_ClientMaster cm = (from c in dbc.tbl_ClientMasters
                                   where c.Id == id
                                   select c).SingleOrDefault();
            cm.AssignTo = assignto;
            cm.BranchId = branchid;
            cm.ClientName = clientname;
            cm.ContactNo = contactno;
            cm.Email = email;
            cm.Gender = gender;
            cm.Service = service;
            cm.Source = source;
            cm.Status = status;
            cm.Status = status;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }


    //Branch Master 

    public int branchmaster_insert(string branchname, string city, string pincode, string fulladdress, string landmark, string mobile, string whatsapp, string email, string category, string googlemap, string gstnumber, string managername, string managermobile, string manageremail, string loginid, string password, Boolean status, DateTime createdat, Int64 createdby, DateTime modifiedat, Int64 modifiedby, string branchphoto, string branchtype)
    {
        try
        {
            tbl_BranchMaster bm = new tbl_BranchMaster();
            bm.BranchName = branchname;
            bm.BranchPhoto = branchphoto;
            bm.BranchType = branchtype;
            bm.Category = category;
            bm.City = city;
            bm.CreatedAt = createdat;
            bm.CreatedBy = createdby;
            bm.Email = email;
            bm.FullAddress = fulladdress;
            bm.GoogleMapLocation = googlemap;
            bm.GSTNumber = gstnumber;
            bm.LandMark = landmark;
            bm.Loginid = loginid;
            bm.ManagerEmail = manageremail;
            bm.ManagerMobile = managermobile;
            bm.ManagerName = managername;
            bm.Mobile = mobile;
            bm.ModifiedAt = modifiedat;
            bm.ModifiedBy = modifiedby;
            bm.Password = password;
            bm.PINcode = pincode;
            bm.Status = status;
            bm.WhatsApp = whatsapp;

            dbc = new DataClassesDataContext();
            dbc.tbl_BranchMasters.InsertOnSubmit(bm);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_BranchMaster> get_branchmasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_BranchMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_BranchMaster> get_branchmasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_BranchMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_branchmaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_BranchMasters
                     where c.Id == id
                     select c).SingleOrDefault();

            dbc.tbl_BranchMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_branchmaster(Int64 id, string branchname, string city, string pincode, string fulladdress, string landmark, string mobile, string whatsapp, string email, string category, string googlemap, string gstnumber, string managername, string managermobile, string manageremail, string loginid, string password, Boolean status, DateTime createdat, Int64 createdby, DateTime modifiedat, Int64 modifiedby, string branchphoto, string branchtype)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_BranchMaster bm = (from c in dbc.tbl_BranchMasters
                                   where c.Id == id
                                   select c).SingleOrDefault();
            bm.BranchName = branchname;
            bm.BranchPhoto = branchphoto;
            bm.BranchType = branchtype;
            bm.Category = category;
            bm.City = city;
            bm.CreatedAt = createdat;
            bm.CreatedBy = createdby;
            bm.Email = email;
            bm.FullAddress = fulladdress;
            bm.GoogleMapLocation = googlemap;
            bm.GSTNumber = gstnumber;
            bm.LandMark = landmark;
            bm.Loginid = loginid;
            bm.ManagerEmail = manageremail;
            bm.ManagerMobile = managermobile;
            bm.ManagerName = managername;
            bm.Mobile = mobile;
            bm.ModifiedAt = modifiedat;
            bm.ModifiedBy = modifiedby;
            bm.Password = password;
            bm.PINcode = pincode;
            bm.Status = status;
            bm.WhatsApp = whatsapp;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    //CustomerMaster

    public int Customermaster_insert(string firstname, string lastname, string email, string mobile, DateTime dob, string gender, Boolean status, Boolean walletaccount, decimal openingbalance, Boolean verified, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_CustomerMaster cm = new tbl_CustomerMaster();

            cm.CreatedAt = createdat;
            cm.DateOfBirth = dob;
            cm.Email = email;
            cm.FirstName = firstname;
            cm.Gender = gender;
            cm.LastName = lastname;
            cm.Mobile = mobile;
            cm.ModifiedAt = modifiedat;
            cm.OpeningBalance = openingbalance;
            cm.Status = status;
            cm.Verified = verified;
            cm.WalletAccount = walletaccount;

            dbc = new DataClassesDataContext();
            dbc.tbl_CustomerMasters.InsertOnSubmit(cm);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_CustomerMaster> get_customermasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_CustomerMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_CustomerMaster> get_customermasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_CustomerMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_customermaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_CustomerMasters
                     where c.Id == id
                     select c).SingleOrDefault();

            dbc.tbl_CustomerMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_customermaster(Int64 id, string firstname, string lastname, string email, string mobile, DateTime dob, string gender, Boolean status, Boolean walletaccount, decimal openingbalance, Boolean verified, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_CustomerMaster cm = (from c in dbc.tbl_CustomerMasters
                                     where c.Id == id
                                     select c).SingleOrDefault();

            cm.CreatedAt = createdat;
            cm.DateOfBirth = dob;
            cm.Email = email;
            cm.FirstName = firstname;
            cm.Gender = gender;
            cm.LastName = lastname;
            cm.Mobile = mobile;
            cm.ModifiedAt = modifiedat;
            cm.OpeningBalance = openingbalance;
            cm.Status = status;
            cm.Verified = verified;
            cm.WalletAccount = walletaccount;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    //WalletTransaction

    public int wallettransactionmaster_insert(Int64 customername, string transactionname, string referenceno, string transactionfrom, DateTime transactondate, string trasactiontype, decimal amount, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_WalletTransaction wt = new tbl_WalletTransaction();

            wt.Amount = amount;
            wt.CreatedAt = createdat;
            wt.CustomerId = customername;
            wt.ModifiedAt = modifiedat;
            wt.ReferenceNo = referenceno;
            wt.TransactionDate = transactondate;
            wt.TransactionFrom = transactionfrom;
            wt.TransactionName = transactionname;
            wt.TransactionType = trasactiontype;

            dbc = new DataClassesDataContext();
            dbc.tbl_WalletTransactions.InsertOnSubmit(wt);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_WalletTransaction> get_wallettransactionmasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_WalletTransactions
                 select c).ToList();
        return d;
    }

    public List<tbl_WalletTransaction> get_wallettransactionmasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_WalletTransactions
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_wallettransactionmaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_WalletTransactions
                     where c.Id == id
                     select c).SingleOrDefault();

            dbc.tbl_WalletTransactions.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_wallettransactionmaster(Int64 id, Int64 customername, string transactionname, string referenceno, string transactionfrom, DateTime transactondate, string trasactiontype, decimal amount, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_WalletTransaction wt = (from c in dbc.tbl_WalletTransactions
                                        where c.Id == id
                                        select c).SingleOrDefault();
            wt.Amount = amount;
            wt.CreatedAt = createdat;
            wt.CustomerId = customername;
            wt.ModifiedAt = modifiedat;
            wt.ReferenceNo = referenceno;
            wt.TransactionDate = transactondate;
            wt.TransactionFrom = transactionfrom;
            wt.TransactionName = transactionname;
            wt.TransactionType = trasactiontype;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }


    //SuplierMaster

    public int supliermaster_insert(Int64 BranchId, string supliername, string supliermobile, string suplieraddress, Boolean status, string email, decimal openingbalance, string gstnumber, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_SuplierMaster sm = new tbl_SuplierMaster();
            sm.BranchId = BranchId;
            sm.CreatedAt = createdat;
            sm.Email = email;
            sm.GSTNumber = gstnumber;
            sm.ModifiedAt = modifiedat;
            sm.Status = status;
            sm.SuplierAddress = suplieraddress;
            sm.SuplierMobile = supliermobile;
            sm.SuplierName = supliername;
            sm.OpeningBalance = openingbalance;



            dbc = new DataClassesDataContext();
            dbc.tbl_SuplierMasters.InsertOnSubmit(sm);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_SuplierMaster> get_supliermasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_SuplierMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_SuplierMaster> get_supliermasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_SuplierMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_supliermaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_SuplierMasters
                     where c.Id == id
                     select c).SingleOrDefault();

            dbc.tbl_SuplierMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_supliermaster(Int64 id, Int64 BranchId, string supliername, string supliermobile, string suplieraddress, Boolean status, string email, decimal openingbalance, string gstnumber, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_SuplierMaster sm = (from c in dbc.tbl_SuplierMasters
                                    where c.Id == id
                                    select c).SingleOrDefault();
            sm.BranchId = BranchId;
            sm.CreatedAt = createdat;
            sm.Email = email;
            sm.GSTNumber = gstnumber;
            sm.ModifiedAt = modifiedat;
            sm.Status = status;
            sm.SuplierAddress = suplieraddress;
            sm.SuplierMobile = supliermobile;
            sm.SuplierName = supliername;
            sm.OpeningBalance = openingbalance;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }
    //OTP Master

    public int otpmaster_insert(Int64 BranchId, string otpfor, string otpby, string otpnumber, Boolean expirystatus, Int64 fkid, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_OTPMaster om = new tbl_OTPMaster();
            om.CreatedAt = createdat;
            om.ExpiryStatus = expirystatus;
            om.FKId = fkid;
            om.ModifiedAt = modifiedat;
            om.OTPBy = otpby;
            om.OTPfor = otpfor;
            om.OTPNumber = otpnumber;


            dbc = new DataClassesDataContext();
            dbc.tbl_OTPMasters.InsertOnSubmit(om);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_OTPMaster> get_otpmasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_OTPMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_OTPMaster> get_otpmasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_OTPMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_otpmaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_OTPMasters
                     where c.Id == id
                     select c).SingleOrDefault();

            dbc.tbl_OTPMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_otpmaster(Int64 id, Int64 BranchId, string otpfor, string otpby, string otpnumber, Boolean expirystatus, Int64 fkid, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_OTPMaster om = (from c in dbc.tbl_OTPMasters
                                where c.Id == id
                                select c).SingleOrDefault();

            om.CreatedAt = createdat;
            om.ExpiryStatus = expirystatus;
            om.FKId = fkid;
            om.ModifiedAt = modifiedat;
            om.OTPBy = otpby;
            om.OTPfor = otpfor;
            om.OTPNumber = otpnumber;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }


    //NewsMaster

    public int newsaster_insert(DateTime newsdate, string newsheading, string newsdescription, Int64 employeeid, Boolean status, string newsstyle, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_NewsMaster nm = new tbl_NewsMaster();
            nm.CreatedAt = createdat;
            nm.EmployeeId = employeeid;
            nm.ModifiedAt = modifiedat;
            nm.NewsDate = newsdate;
            nm.NewsDescription = newsdescription;
            nm.NewsHeading = newsheading;
            nm.NewsStyle = newsstyle;
            nm.Status = status;

           
            dbc.tbl_NewsMasters.InsertOnSubmit(nm);
            dbc.SubmitChanges();
            return 1;

        }
        catch
        {
            return 0;
        }
    }
    public List<tbl_NewsMaster> get_newsmasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_NewsMasters
                 select c).ToList();
        return d;
    }
    public List<tbl_NewsMaster> get_newsmasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_NewsMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }
    public int delete_newsmaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_NewsMasters
                     where c.Id == id
                     select c).SingleOrDefault();



            dbc.tbl_NewsMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }
    public int update_newsmaster(Int64 id, DateTime newsdate, string newsheading, string newsdescription, Int64 employeeid, Boolean status, string newsstyle, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_NewsMaster nm = (from c in dbc.tbl_NewsMasters
                                 where c.Id == id
                                 select c).SingleOrDefault();

            nm.CreatedAt = createdat;
            nm.EmployeeId = employeeid;
            nm.ModifiedAt = modifiedat;
            nm.NewsDate = newsdate;
            nm.NewsDescription = newsdescription;
            nm.NewsHeading = newsheading;
            nm.NewsStyle = newsstyle;
            nm.Status = status;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    //StockInOutMaster

    public int stockinoutmaster_insert(Int64 suplierid, Int64 branchid, string type, string invoicenumber, DateTime invoicedate, string supliername, decimal totalquantity, decimal totaltaxableamount, decimal totalgst, decimal totaligst, decimal totalsgst, decimal totalcgst, decimal netamount, decimal totaldiscount, decimal totalamount, string remark, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_StokeInOutMaster sm = new tbl_StokeInOutMaster();

            sm.BranchId = branchid;
            sm.CreatedAt = createdat;
            sm.InvoiceDate = invoicedate;
            sm.InvoiceNumber = invoicenumber;
            sm.ModifiedAt = modifiedat;
            sm.NetAmount = netamount;
            sm.Remark = remark;
            sm.SuplierId = suplierid;
            sm.SuplierName = supliername;
            sm.TotalAmount = totalamount;
            sm.TotalCGST = totalcgst;
            sm.TotalDiscount = totaldiscount;
            sm.TotalGST = totalgst;
            sm.TotalIGST = totaligst;
            sm.TotalQuantity = totalquantity;
            sm.TotalSGST = totalsgst;
            sm.TotalTaxableAmount = totaltaxableamount;
            sm.Type = type;

            dbc = new DataClassesDataContext();
            dbc.tbl_StokeInOutMasters.InsertOnSubmit(sm);
            dbc.SubmitChanges();
            return 1;

        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_StokeInOutMaster> get_stokeinoutmasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_StokeInOutMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_StokeInOutMaster> get_stokeinoutmasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_StokeInOutMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_stokeinoutmaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_StokeInOutMasters
                     where c.Id == id
                     select c).SingleOrDefault();



            dbc.tbl_StokeInOutMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_stockinoutmaster(Int64 id, Int64 suplierid, Int64 branchid, string type, string invoicenumber, DateTime invoicedate, string supliername, decimal totalquantity, decimal totaltaxableamount, decimal totalgst, decimal totaligst, decimal totalsgst, decimal totalcgst, decimal netamount, decimal totaldiscount, decimal totalamount, string remark, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_StokeInOutMaster sm = (from c in dbc.tbl_StokeInOutMasters
                                       where c.Id == id
                                       select c).SingleOrDefault();

            sm.BranchId = branchid;
            sm.CreatedAt = createdat;
            sm.InvoiceDate = invoicedate;
            sm.InvoiceNumber = invoicenumber;
            sm.ModifiedAt = modifiedat;
            sm.NetAmount = netamount;
            sm.Remark = remark;
            sm.SuplierId = suplierid;
            sm.SuplierName = supliername;
            sm.TotalAmount = totalamount;
            sm.TotalCGST = totalcgst;
            sm.TotalDiscount = totaldiscount;
            sm.TotalGST = totalgst;
            sm.TotalIGST = totaligst;
            sm.TotalQuantity = totalquantity;
            sm.TotalSGST = totalsgst;
            sm.TotalTaxableAmount = totaltaxableamount;
            sm.Type = type;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    //StockinOutDetailMaster

    public int stockinoutdetailmaster_insert(Int64 productid, Int64 stockinoutid, string HSNcode, string Productdetail, DateTime manufacturedate, DateTime expirydate, decimal quantity, decimal rate, decimal discount, string  discounttype, decimal discountpercentage, decimal amount, decimal netamount, decimal taxableamount, decimal gstpercentage,decimal gstamount,decimal cgstamount,decimal sgstamount,decimal igstamount,decimal netamt,decimal unit, string remark, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            tbl_StockInOutDetailMaster sm = new tbl_StockInOutDetailMaster();

            sm.Amount = amount;
            sm.CGSTamount = cgstamount;
            sm.CreatedAt = createdat;
            sm.Discount = discount;
            sm.DiscountPercentage = discountpercentage;
            sm.DiscountType = discounttype;
            sm.ExpiryDate = expirydate;
            sm.GSTAmount = gstamount;
            sm.GSTPercentage = gstpercentage;
            sm.HSNCode = HSNcode;
            sm.IGSTamount = igstamount;
            sm.ManufactureDate = manufacturedate;
            sm.ModifiedAt = modifiedat;
            sm.Netamount = netamount;
            sm.ProductDetail = Productdetail;
            sm.ProductId = productid;
            sm.Quantity = quantity;
            sm.Rate = rate;
            sm.Remark = remark;
            sm.SGSTamount = sgstamount;
            sm.StockInOutId = stockinoutid;
            sm.TaxableAmount = taxableamount;
            sm.Unit = unit;

            dbc = new DataClassesDataContext();
            dbc.tbl_StockInOutDetailMasters.InsertOnSubmit(sm);
            dbc.SubmitChanges();
            return 1;

        }
        catch
        {
            return 0;
        }
    }

    public List<tbl_StockInOutDetailMaster> get_stokeinoutdetailmasterlist()
    {
        dbc = new DataClassesDataContext();
        var d = (from c in dbc.tbl_StockInOutDetailMasters
                 select c).ToList();
        return d;
    }

    public List<tbl_StockInOutDetailMaster> get_stokeinoutdetailmasterlistby_id(Int64 id)
    {
        dbc = new DataClassesDataContext();
        var p = (from c in dbc.tbl_StockInOutDetailMasters
                 where c.Id == id
                 select c).ToList();
        return p;
    }

    public int delete_stokeinoutdetailmaster(Int64 id)
    {
        dbc = new DataClassesDataContext();
        try
        {
            var p = (from c in dbc.tbl_StockInOutDetailMasters
                     where c.Id == id
                     select c).SingleOrDefault();



            dbc.tbl_StockInOutDetailMasters.DeleteOnSubmit(p);
            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int update_stockinoutdetailmaster(Int64 id, Int64 productid, Int64 stockinoutid, string HSNcode, string Productdetail, DateTime manufacturedate, DateTime expirydate, decimal quantity, decimal rate, decimal discount, string discounttype, decimal discountpercentage, decimal amount, decimal netamount, decimal taxableamount, decimal gstpercentage, decimal gstamount, decimal cgstamount, decimal sgstamount, decimal igstamount, decimal netamt, decimal unit, string remark, DateTime createdat, DateTime modifiedat)
    {
        try
        {
            dbc = new DataClassesDataContext();
            tbl_StockInOutDetailMaster sm = (from c in dbc.tbl_StockInOutDetailMasters
                                       where c.Id == id
                                       select c).SingleOrDefault();

            sm.Amount = amount;
            sm.CGSTamount = cgstamount;
            sm.CreatedAt = createdat;
            sm.Discount = discount;
            sm.DiscountPercentage = discountpercentage;
            sm.DiscountType = discounttype;
            sm.ExpiryDate = expirydate;
            sm.GSTAmount = gstamount;
            sm.GSTPercentage = gstpercentage;
            sm.HSNCode = HSNcode;
            sm.IGSTamount = igstamount;
            sm.ManufactureDate = manufacturedate;
            sm.ModifiedAt = modifiedat;
            sm.Netamount = netamount;
            sm.ProductDetail = Productdetail;
            sm.ProductId = productid;
            sm.Quantity = quantity;
            sm.Rate = rate;
            sm.Remark = remark;
            sm.SGSTamount = sgstamount;
            sm.StockInOutId = stockinoutid;
            sm.TaxableAmount = taxableamount;
            sm.Unit = unit;

            dbc.SubmitChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }
}


