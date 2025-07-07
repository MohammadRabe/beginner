using System.Collections;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
namespace DSA
{
    
    internal class Program
    {
        public static void Main(string[] args) 
        { 
            
        }
    }



}
public interface IApi
{
    public void Notify(string command);
}
public class GoogleHomeApi : IApi
{
    public void Notify(string command)
    {
        // call external API
    }
   

}
public interface IDatabase
{
    public void SaveToDatabase(string message);
    
}
public class SqlDatabase : IDatabase
{
    public void SaveToDatabase(string log)
    {
        // save to DB
    }
}
public interface ISender
{
    public void Send(string msg);
}
public class EmailSender : ISender
{
    public void Send(string message)
    {
        // send email
    }
}
public class SmsSender : ISender
{
    public void Send(string message)
    {
        // send SMS
    }

}

public abstract class Alert
{
    public abstract void SendAlert(string message);
}
public class TempAlert : Alert 
{
    private ISender _sender;
    public TempAlert(ISender sndr)
    {
        _sender = sndr;
    }
    public override void SendAlert(string msg)
    {
        _sender.Send(msg);
    }
}
public abstract class SmartManger
{
    public List<SmartDevice> devices = new List<SmartDevice>();
    public abstract void AddDevice(SmartDevice device);
}
public class SmartHomeManager : SmartManger
{

    public override void AddDevice(SmartDevice device)
    {
        devices.Add(device);
    }
}
public abstract class Monitor
{
    protected SmartManger _smartManager;
    protected Alert _alert;
   
    public Monitor(SmartManger smrtmngr, Alert alertType)
    {
        _smartManager = smrtmngr;
        _alert = alertType;
        
    }
    public abstract void MonitorDevices();
}
public class TempMonitor : Monitor
{
    public TempMonitor(SmartManger smrtmngr, Alert alertType) : base(smrtmngr, alertType) { }

    public override void MonitorDevices()
    {
        foreach (var device in _smartManager.devices)
        {
            if (device is TempSensor tempSensor)
            {
                var value = tempSensor.ReadTemperature();
                if (value > 30)
                {
                    _alert.SendAlert($"High temperature detected by {device.Name}: {value}°C");
                }
            }
        }

    }
}



public class DevicesController
{
    private SmartManger _manager;
    private IDatabase _database;
    private Alert _alertSender;
    private IApi _api;
    public DevicesController(SmartManger mngr, IDatabase db, Alert alrt, IApi api)
    {
        _manager = mngr;
        _database = db;
        _alertSender = alrt;
        _api = api;
    }
    public void TurnOnAllDevices()
    {
        foreach (var device in _manager.devices)
        {
            device.TurnOn();                                                        // The logic is in other classes so there is no violation to SRP                 
            _database.SaveToDatabase($"{device.Name} turned ON at {DateTime.Now}");    
            _alertSender.SendAlert($"{device.Name} has been activated.");
            _api.Notify(device.Name + " is now ON");
        }
    }

    public void TurnOffAllDevices()
    {
        foreach (var device in _manager.devices)
        {
            device.TurnOff();
            _database.SaveToDatabase($"{device.Name} turned OFF at {DateTime.Now}");
            _alertSender.SendAlert($"{device.Name} has been deactivated.");
        }
    }

}


public abstract class SmartDevice 
{
    public string Name { get; set; }
    public string Type { get; set; }

    public abstract void TurnOn();
    public abstract void TurnOff();
    
    
}
public class SmartLamp : SmartDevice
{
    public override void TurnOn() { /*   */}
    public override void TurnOff() { /*   */}
}

public class TempSensor : SmartDevice
{
    public override void TurnOn() { /*   */}
    public override void TurnOff() { /*   */}
    public double ReadTemperature()
    {
        return new Random().NextDouble() * 40;
    }

}





