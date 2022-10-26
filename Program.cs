using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace UIAutomationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the Emulator");

            //new Thread(() =>
            //{
            //    Thread.CurrentThread.IsBackground = true;
            //    /* run your code here */
            //    Console.WriteLine("Hello, world");
            //    var openEmulatorCommand = "emulator -avd pixel_3_xl_r_11_0_-_api_30";
            //    System.Diagnostics.ProcessStartInfo emulatorProcessStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + openEmulatorCommand);
            //    emulatorProcessStartInfo.RedirectStandardOutput = true;
            //    emulatorProcessStartInfo.UseShellExecute = false;
            //    emulatorProcessStartInfo.WorkingDirectory = "C:\\Users\\ChozarajanPandiyaraj\\AppData\\Local\\Android\\Sdk\\emulator\\";

            //    Process emulatorProcess = new Process();
            //    emulatorProcess.StartInfo = emulatorProcessStartInfo;
            //    emulatorProcess.Start();
            //    string emulatorResult = emulatorProcess.StandardOutput.ReadToEnd();
            //    Console.WriteLine(emulatorResult);
            //}).Start();


            var newFolderCommand = "mkdir D:\\Automation\\";
            System.Diagnostics.ProcessStartInfo newFolderStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + newFolderCommand);
            newFolderStartInfo.RedirectStandardOutput = true;
            newFolderStartInfo.UseShellExecute = false;

            Process newFolderProcess = new Process();
            newFolderProcess.StartInfo = newFolderStartInfo;
            newFolderProcess.Start();
            string newFolderResult = newFolderProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(newFolderResult);

            var sourceClonecommand = "git clone https://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@github.com/essential-studio/sfrating-xamarin-tests.git";
            System.Diagnostics.ProcessStartInfo sourceCloneProcStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + sourceClonecommand);
            sourceCloneProcStartInfo.RedirectStandardOutput = true;
            sourceCloneProcStartInfo.UseShellExecute = false;
            sourceCloneProcStartInfo.WorkingDirectory = "D:\\Automation";

            Process sourceCloneProcess = new Process();
            sourceCloneProcess.StartInfo = sourceCloneProcStartInfo;
            sourceCloneProcess.Start();
            string sourceCloneResult = sourceCloneProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(sourceCloneResult);

            var switchBranchCommand = "git switch CloudCheck";
            System.Diagnostics.ProcessStartInfo switchBranchProcStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + switchBranchCommand);
            switchBranchProcStartInfo.RedirectStandardOutput = true;
            switchBranchProcStartInfo.UseShellExecute = false;
            switchBranchProcStartInfo.WorkingDirectory = "D:\\Automation\\sfrating-xamarin-tests\\";

            Process switchBranchProcess = new Process();
            switchBranchProcess.StartInfo = switchBranchProcStartInfo;
            switchBranchProcess.Start();
            string switchBranchResult = switchBranchProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(switchBranchResult);

            Console.WriteLine("Compilation Start");
            var addEnvironmentMsBuildCommand = "set PATH=%PATH%;C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\BuildTools\\MSBuild\\Current\\Bin";
            var restoreProjectCommand = "msbuild /t:restore";
            var compileSourceCommand = "msbuild SfRatingSample.Android\\SfRatingSample.Android.csproj /verbosity:normal /t:Rebuild /t:PackageForAndroid /t:SignAndroidPackage /p:Configuration=Release";
            System.Diagnostics.ProcessStartInfo compileSourceProcStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + addEnvironmentMsBuildCommand + "&" + restoreProjectCommand + "&" + compileSourceCommand);
            compileSourceProcStartInfo.RedirectStandardOutput = true;
            compileSourceProcStartInfo.UseShellExecute = false;
            compileSourceProcStartInfo.WorkingDirectory = "D:\\Automation\\sfrating-xamarin-tests\\UITest\\XForms\\SfRatingSample\\";

            Process compileSourceProcess = new Process();
            compileSourceProcess.StartInfo = compileSourceProcStartInfo;
            compileSourceProcess.Start();
            string compileSourceResult = compileSourceProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(compileSourceResult);

            Console.WriteLine("Compile End");

            Console.WriteLine("Publish Start");
            var publishAPKCommand = "adb install com.companyname.sfratingsample-Signed.apk";
            System.Diagnostics.ProcessStartInfo publishAPKProcStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + publishAPKCommand);
            publishAPKProcStartInfo.RedirectStandardOutput = true;
            publishAPKProcStartInfo.UseShellExecute = false;
            publishAPKProcStartInfo.WorkingDirectory = "D:\\Automation\\sfrating-xamarin-tests\\UITest\\XForms\\SfRatingSample\\SfRatingSample.Android\\bin\\Release\\";

            Process publishAPKProcess = new Process();
            publishAPKProcess.StartInfo = publishAPKProcStartInfo;
            publishAPKProcess.Start();
            string publishAPKResult = publishAPKProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(publishAPKResult);

            Console.WriteLine("Publish End");

        }
    }
}
