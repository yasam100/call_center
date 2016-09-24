using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models.ContentLayerDummy
{
    public class ContentDummy
    {

        public class EmployeeContentProviderDummy : IContentProvider<Employee>
        {
            ICollection<Employee> _repository = new HashSet<Employee>
        {
            new Employee {Id=123,FirstName="Moshe123",LastName="Cohen123",Password="1234",Phone="05212312313", UserName="moshec123" },
            new Employee {Id=124,FirstName="Moshe124",LastName="Cohen124",Password="1234",Phone="05212312314", UserName="moshec124" },
            new Employee {Id=125,FirstName="Moshe125",LastName="Cohen125",Password="1234",Phone="05212312315", UserName="moshec125" },
            new Employee {Id=126,FirstName="Moshe126",LastName="Cohen126",Password="1234",Phone="05212312316", UserName="moshec126" },
            new Employee {Id=127,FirstName="Moshe127",LastName="Cohen127",Password="1234",Phone="05212312317", UserName="moshec127" }
        };

            public int Delete(Employee itemToDelete)
            {
                throw new NotImplementedException();
            }

            public int Insert(Employee itemToInsert)
            {
                throw new NotImplementedException();
            }

            public ICollection<Employee> Query()
            {
                return _repository;
            }

            public ICollection<Employee> QueryById(int id)
            {
                return _repository.Where(e => e.Id == id).ToList();
            }

            public int Update(Employee item)
            {
                throw new NotImplementedException();
            }
        }

        public static EmployeeContentProviderDummy EmployeeContentProvider = new EmployeeContentProviderDummy();

        public class CustomerContentProviderDummy : IContentProvider<Customer>
        {
            ICollection<Customer> _repository = new HashSet<Customer>
            {
                new Customer {Id=234, FirstName="Eli234", LastName="Levi234", Phone="07823423424" },
                new Customer {Id=235, FirstName="Eli235", LastName="Levi235", Phone="07823423425" },
                new Customer {Id=236, FirstName="Eli236", LastName="Levi236", Phone="07823423426" }
            };

            public int Delete(Customer itemToDelete)
            {
                throw new NotImplementedException();
            }

            public int Insert(Customer itemToInsert)
            {
                throw new NotImplementedException();
            }

            public ICollection<Customer> Query()
            {
                return _repository;
            }

            public ICollection<Customer> QueryById(int id)
            {
                return _repository.Where(c => c.Id == id).ToList();
            }

            public int Update(Customer item)
            {
                throw new NotImplementedException();
            }
        }

        public static CustomerContentProviderDummy CustomerContentProvider = new CustomerContentProviderDummy();

        public class ServiceCallContentProviderDummy : IContentProvider<ServiceCall>
        {
            ICollection<ServiceCall> _repository = new HashSet<ServiceCall>
            {
                new ServiceCall
                {
                    Id = 345,
                    CustomerId = 234,
                    Caller = CustomerContentProvider.QueryById(234).FirstOrDefault(),
                    OpenDate = DateTime.Now.AddDays(-234),
                    OpenByAgentId = 124,
                    OpenByAgent = EmployeeContentProvider.QueryById(124).FirstOrDefault(),
                    Status = StatusType.OPEN,
                    Priority = PriorityType.MEDIUM,
                    Issue = "Lorem ipsum dolor sit amet, per cu facer honestatis temporibus, placerat sensibus per in. Id fuisset singulis vituperatoribus quo. Cu sit summo recteque. Ex usu eros molestiae, sit ex populo volumus. Mei falli electram adipiscing id, nam autem hendrerit abhorreant ea.\n\n"
                    + "Sed at illud disputationi, te alterum vivendum salutatus per, tota integre singulis in qui. Id ferri tantas assueverit pri, eu novum salutandi incorrupte ius. Ex has prima consetetur, eum enim diceret et, quo possit maiorum efficiendi et. Sed officiis petentium democritum ut. Erat corrumpit urbanitas ut vim, nam legendos repudiandae ei. Debitis ocurreret ei mei, accusam singulis liberavisse vis ea."
                },
                new ServiceCall
                {
                    Id = 346,
                    CustomerId = 235,
                    Caller = CustomerContentProvider.QueryById(235).FirstOrDefault(),
                    OpenDate = DateTime.Now.AddDays(-235),
                    OpenByAgentId = 125,
                    OpenByAgent = EmployeeContentProvider.QueryById(125).FirstOrDefault(),
                    Status = StatusType.IN_PROGRESS,
                    Priority = PriorityType.HIGH,
                    Issue = "Sed at illud disputationi, te alterum vivendum salutatus per, tota integre singulis in qui. Id ferri tantas assueverit pri, eu novum salutandi incorrupte ius. Ex has prima consetetur, eum enim diceret et, quo possit maiorum efficiendi et. Sed officiis petentium democritum ut. Erat corrumpit urbanitas ut vim, nam legendos repudiandae ei. Debitis ocurreret ei mei, accusam singulis liberavisse vis ea."
                },
                new ServiceCall
                {
                    Id = 347,
                    CustomerId = 235,
                    Caller = CustomerContentProvider.QueryById(235).FirstOrDefault(),
                    OpenDate = DateTime.Now.AddDays(-235),
                    OpenByAgentId = 123,
                    OpenByAgent = EmployeeContentProvider.QueryById(123).FirstOrDefault(),
                    Status = StatusType.CLOSED,
                    Priority = PriorityType.LOW,
                    Issue = "Sed at illud dispuam legendos repudiandae ei. Debitis ocurreret ei mei, accusam singulis liberavisse vis ea.",
                    Solution = "Done",
                    CloseByAgentId = 126,
                    CloseByAgent = EmployeeContentProvider.QueryById(126).SingleOrDefault(),
                    CloseDate = DateTime.Now
                }
            };

            public int Delete(ServiceCall itemToDelete)
            {
                throw new NotImplementedException();
            }

            public int Insert(ServiceCall itemToInsert)
            {
                throw new NotImplementedException();
            }

            public ICollection<ServiceCall> Query()
            {
                return _repository;
            }

            public ICollection<ServiceCall> QueryById(int id)
            {
                return _repository.Where(sc => sc.Id == id).ToList();
            }

            public int Update(ServiceCall item)
            {
                throw new NotImplementedException();
            }
        }

        public static ServiceCallContentProviderDummy ServiceCallContentProvider = new ServiceCallContentProviderDummy();

    }
}
