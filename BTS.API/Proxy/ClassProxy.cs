using ClassService;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using BTS.API.Models;
using System.Collections.Generic;

namespace BTS.API.Proxy
{
    public class ClassProxy
    {
        private string sourcename;
        private string password;
        private ClassServiceSoapClient proxy; 

        public ClassProxy()
        {
            sourcename = "BTS";
            password = "HA7zucCmsoTvyYSYCNllvJP0BBU="; // OBVS this is going to be coming from a configuration
            Binding binding = new BasicHttpsBinding();
            EndpointAddress address = new EndpointAddress("https://api.mindbodyonline.com/0_5/ClassService.asmx");
            proxy = new ClassServiceSoapClient(binding, address);
            //////!!! ^^^ CAN I DO SOMETHING WITH DEPENDENCY INJECTION FOR THIS TO AUTOPOPULATE THESE CLIENTS WITH THE SAME UNCHANGING INFO?
        }

        public async Task<List<ClassApiModel>> GetAllClasses()
        {
            var request = CreateDefaultRequest(); 
            var result = await proxy.GetClassesAsync(request);
            return result.Body.GetClassesResult.Classes.OfType<Class>().AsEnumerable().Select(c => Mapper.Map<Class, ClassApiModel>(c)).ToList();
        }

        private GetClassesRequest CreateDefaultRequest()
        {
            return new GetClassesRequest()
            {
                SourceCredentials = new SourceCredentials()
                {
                    SourceName = sourcename,
                    Password = password,
                    SiteIDs = new ArrayOfInt() { -99 }
                }
            };
        }
    }
}
