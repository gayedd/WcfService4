using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService4
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    namespace MessagingApp
    {
        [ServiceContract(CallbackContract = typeof(IMessagingCallback))]
        public interface IMessagingService
        {
            [OperationContract]
            void Connect(string username);

            [OperationContract]
            void Disconnect(string username);

            [OperationContract]
            void SendMessage(string message, string senderUsername);
        }

        public interface IMessagingCallback
        {
            [OperationContract(IsOneWay = true)]
            void ReceiveMessage(string message, string senderUsername);
        }

        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
        public class MessagingService : IMessagingService
        {
            private Dictionary<string, IMessagingCallback> connectedClients = new Dictionary<string, IMessagingCallback>();

            public void Connect(string username)
            {
                IMessagingCallback callback = OperationContext.Current.GetCallbackChannel<IMessagingCallback>();

                if (!connectedClients.ContainsKey(username))
                {
                    connectedClients.Add(username, callback);
                    Console.WriteLine("{0} kullanıcısı bağlandı.", username);
                }
            }

            public void Disconnect(string username)
            {
                if (connectedClients.ContainsKey(username))
                {
                    connectedClients.Remove(username);
                    Console.WriteLine("{0} kullanıcısı ayrıldı.", username);
                }
            }

            public void SendMessage(string message, string senderUsername)
            {
                Console.WriteLine("{0}: {1}", senderUsername, message);

                foreach (var callback in connectedClients.Values)
                {
                    callback.ReceiveMessage(message, senderUsername);
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                ServiceHost host = new ServiceHost(typeof(MessagingService));
                host.Open();

                Console.WriteLine("Sunucu çalışıyor. İstemci bağlantılarını bekliyor...");
                Console.ReadLine();

                host.Close();
            }
        }
    }
    // NOT: "Service1" sınıf adını kodda, svc'de ve yapılandırma dosyasında birlikte değiştirmek için "Yeniden Düzenle" menüsündeki "Yeniden Adlandır" komutunu kullanabilirsiniz.
    // NOT: Bu hizmeti test etmek üzere WCF Test İstemcisi'ni başlatmak için lütfen Çözüm Gezgini'nde Service1.svc'yi veya Service1.svc.cs'yi seçin ve hata ayıklamaya başlayın.
    public class Service1 : IService1using System;
using System.ServiceModel;

namespace MessagingApp
    {
        public class MessagingCallback : IMessagingServiceCallback
        {
            public void ReceiveMessage(string message, string senderUsername)
            {
                Console.WriteLine("{0}: {1}", senderUsername, message);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Kullanıcı adınızı girin: ");
                string username = Console.ReadLine();

                // Sunucu adresini ve bağlantı noktasını belirleyin
                string serverAddress = "http://localhost:8000/MessagingService";

                // İstemciye bir geri çağırım nesnesi atanır
                MessagingCallback callback = new MessagingCallback();
                InstanceContext context = new InstanceContext(callback);

                // WCF kanalı oluşturulur ve sunucuya bağlanılır
                DuplexChannelFactory<IMessagingService> channelFactory = new DuplexChannelFactory<IMessagingService>(context, new WSDualHttpBinding(), new EndpointAddress(serverAddress));
                IMessagingService messagingService = channelFactory.CreateChannel();

                Console.WriteLine
    
    {
                    public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
