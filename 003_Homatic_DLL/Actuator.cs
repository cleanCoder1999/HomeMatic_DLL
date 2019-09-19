using System;

namespace HomeMatic
{
    public class Actuator
    {
        private string concatedAddress;
        private string dataPoint;
        private IHomeMaticProxy homeMaticProxy;

        public Actuator(IHomeMaticProxy homeMaticProxy)
        {
            this.homeMaticProxy = homeMaticProxy;
            try
            {
                if (ProxyIsNull())
                    throw new Exception();
            }
            catch(Exception)
            {
                Console.WriteLine("[EXCEPTION]: in class Actuator: in Actuator(IHomeMaticProxy homeMaticProxy)");
            }
        }
        private bool ProxyIsNull()
        {
            bool proxyIsNull = false;
            if (homeMaticProxy.Equals(null))
            {
                proxyIsNull = true;
            }
            return proxyIsNull;
        }

        public void SetAddress(
                        string address)
        {
            concatedAddress = address;
        }
        public void SetChannel(
                        string channel)
        {
            concatedAddress += ":" + channel;
        }
        public void SetDataPoint(
                        string dataPoint)
        {
            this.dataPoint = dataPoint;
        }
        public object GetValue()
        {
            try
            {
                return homeMaticProxy.GetValue(
                            concatedAddress,
                            dataPoint);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void SetValue(object value)
        {
            try
            {
                homeMaticProxy.SetValue(
                        concatedAddress,
                        dataPoint,
                        value);
            }
            catch (Exception)
            {
                /**/
            }
        }
    }
}
