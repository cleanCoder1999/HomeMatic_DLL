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
