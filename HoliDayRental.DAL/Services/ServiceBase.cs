
namespace HoliDayRental.DAL.Services
{
    public abstract class ServiceBase
    {
        protected string _connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HoliDayRental;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
