using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace captchaBomber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 説明はここ！
            // https://2captcha.com/2captcha-api#examples
        }

        #region capcha
        public string SendRecaptchav2Request(string apiKey, string googleKey, string pageUrl)
        {
            //POST
            try
            {
                System.Net.ServicePointManager.Expect100Continue = false;
                var request = (HttpWebRequest)WebRequest.Create("http://2captcha.com/in.php");

                var postData = "key="+ apiKey + "&method=userrecaptcha&googlekey=GOOGLE KEY&pageurl=" + pageUrl;
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";

                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                //  GET
                if (responseString.Contains("OK|"))
                {
                    return responseString.Substring(0, 3);
                }
                else
                {
                    return "Error";
                }
            }
            catch (Exception e)
            {
                string tt = e.Message;
                return tt;
            }

        }
        #endregion
    }
}
