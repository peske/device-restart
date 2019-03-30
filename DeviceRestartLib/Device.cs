using System.Management.Automation;

namespace DeviceRestartLib
{
    public static class Device
    {
        private static readonly string GetDeviceFormatString =
            "Get-PnpDevice | Where-Object {{$_.FriendlyName -eq '{0}' -and $_.InstanceId -like '{1}*' -and $_.Status -ne 'Unknown'}}";
        private static readonly string DisableDeviceString = " | Disable-PnpDevice -Confirm:$false";
        private static readonly string EnableDeviceString = " | Enable-PnpDevice -Confirm:$false";

        private static string GetCommand(string friendlyName, string instanceId, bool enable) =>
            string.Format(GetDeviceFormatString, friendlyName, instanceId) + (enable ? EnableDeviceString : DisableDeviceString);

        public static void Disable(string friendlyName, string instanceId) =>
            PowerShell.Create().AddScript(GetCommand(friendlyName, instanceId, false)).Invoke();

        public static void Enable(string friendlyName, string instanceId) =>
            PowerShell.Create().AddScript(GetCommand(friendlyName, instanceId, true)).Invoke();
    }
}
