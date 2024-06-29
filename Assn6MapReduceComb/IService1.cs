using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Assn6MapReduceComb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<KeyValuePair<string, int>> map(List<string> textDoc);

        [OperationContract]
        Dictionary<string, int> reduce(List<KeyValuePair<string, int>> values);

        [OperationContract]
        Dictionary<string, int> combine(List<Dictionary<string, int>> toCombine);

        // TODO: Add your service operations here
    }
}
