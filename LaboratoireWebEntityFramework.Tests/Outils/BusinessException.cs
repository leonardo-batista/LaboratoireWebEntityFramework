using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoireWebEntityFramework.Tests.Outils
{
    [Serializable]
    public class BusinessException : Exception
    {
        private BusinessMessage businessMessage_ = new BusinessMessage();

        public BusinessMessage BusinessMessage_
        {
            get { return this.businessMessage_; }
            set
            {
                if (!string.IsNullOrEmpty(businessMessage_.BusinessCode) &&
                    !string.IsNullOrEmpty(businessMessage_.BusinessDescription))
                {
                    this.businessMessage_ = value;
                }

            }
        }

        private IList<BusinessMessage> listBusinessMessage = new List<BusinessMessage>();

        /// <summary>
        /// 
        /// </summary>
        public IList<BusinessMessage> ListBusinessMessage
        {
            get { return this.listBusinessMessage; }
            set { this.listBusinessMessage = value; }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BusinessException() : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessCode_"></param>
        /// <param name="businessDescription_"></param>
        public void AddMessageList(string businessCode_, string businessDescription_)
        {
            BusinessMessage messageBusiness = new BusinessMessage();

            messageBusiness.BusinessCode = businessCode_;
            messageBusiness.BusinessDescription = businessDescription_;

            ListBusinessMessage.Add(messageBusiness);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ListBusinessMessageJson()
        {
            string jsonResult = string.Empty;

            if (ListBusinessMessage.Count > 0)
            {
                //TODO! Telecharger Newtonsoft.Json !!!
                //jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(ListBusinessMessage);
            }

            // List of characters handled:
            // \000 null
            // \010 backspace
            // \011 horizontal tab
            // \012 new line
            // \015 carriage return
            // \032 substitute
            // \042 double quote *
            // \047 single quote
            // \134 backslash 
            // \140 grave accent

            return jsonResult;
        }

        /// <summary>
        /// Argument constructor
        /// </summary>
        /// <param name="message">This is the description of the exception</param>
        public BusinessException(String message) : base(message)
        {

        }

        /// <summary>
        /// Argument constructor with inner exception
        /// </summary>
        /// <param name="message">This is the description of the exception</param>
        /// <param name="innerException">Inner exception</param>
        public BusinessException(String message, Exception innerException) : base(message, innerException)
        {

        }

        /// <summary>
        /// Argument constructor with serialization support
        /// </summary>
        /// <param name="info">Instance of SerializationInfo</param>
        /// <param name="context">Instance of StreamingContext</param>
        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("CheckedOut", DateTime.Now);
        }
    }
}
