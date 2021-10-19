using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDesignExamples.CRUD.Customer;

namespace ApiDesignExamples.CRUD.Migrations.SampleData
{
    public class CustomerData
    {
        private readonly IGenericCustomerRepository _customerRepository;

        public CustomerData(IGenericCustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task PopulateData()
        {
            var customerData = GetInitialCustomerData();



            foreach (var customer in customerData)
            {
                await _customerRepository.Create(customer);
            }
        }

        private IEnumerable<Customer.Customer> GetInitialCustomerData()
        {
            var customerData = new[]
            {
                new
                {
                    Id = "C9918119-292E-0E63-AD6C-75A0D6A726FA",
                    FirstName = "Robin",
                    LastName = "Hammond"
                },
                new
                {
                    Id = "EB08140F-A24A-2CAE-73BC-B328D3705627",
                    FirstName = "Palmer",
                    LastName = "Bishop"
                },
                new
                {
                    Id = "7E0DE969-F2AD-990D-CD1C-DE96B3143225",
                    FirstName = "Kaseem",
                    LastName = "Kelly"
                },
                new
                {
                    Id = "1DC4DCB8-14EB-CB93-33D9-4CE1A37E42BB",
                    FirstName = "Inga",
                    LastName = "Noel"
                },
                new
                {
                    Id = "F91EB45D-9739-63AA-79DE-1A2067999147",
                    FirstName = "Jolie",
                    LastName = "Carney"
                },
                new
                {
                    Id = "1EB47CB4-195B-6557-44CD-E962DC4E65E4",
                    FirstName = "Lee",
                    LastName = "Burnett"
                },
                new
                {
                    Id = "8234C1D3-DEE1-2156-3E99-7E84BB825F61",
                    FirstName = "Graham",
                    LastName = "Hendrix"
                },
                new
                {
                    Id = "65E277B8-5E20-A32D-EB64-3143059C04ED",
                    FirstName = "Robin",
                    LastName = "Guzman"
                },
                new
                {
                    Id = "752F6EF5-E1CC-A81E-A54E-A0A1737DE848",
                    FirstName = "Denise",
                    LastName = "Patterson"
                },
                new
                {
                    Id = "2251E17D-4DC1-AB27-5B61-7EB97D942B26",
                    FirstName = "Jordan",
                    LastName = "Wilkerson"
                }
            };

            return customerData.Select(c => new Customer.Customer
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName
            });
        }

    }
}