using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenesseyXO.Api
{
    public class RequestPool
    {
        public List<Request> Item { private set; get; }
        private string invite_header = "invite:";

        public RequestPool()
        {
            Item = new List<Request>();
        }

        public void AddRequest(Request request)
        {
            Item.Add(request);
            var writer = new StreamWriter(request.Wanted.User.GetStream());
            writer.WriteLine(invite_header + request.Wanter.Name);
            writer.Flush();
        }

        public Request GetByWantedName(string item)
        {
            var result =
                from wanted in Item
                where wanted.Wanted.Name.Equals(item)
                select wanted;
            return result.First();
        }

        public void SendResponse(Request request, string response)
        {
            StreamWriter writer = new StreamWriter(request.Wanted.User.GetStream());
            writer.WriteLine("success:" + response);
            writer.Flush();
            writer = new StreamWriter(request.Wanter.User.GetStream());
            writer.WriteLine("success:" + response);
            writer.Flush();
        }
    }
}
