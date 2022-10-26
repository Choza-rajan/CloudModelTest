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


            var newFolderForSourceCommand = "mkdir D:\\Automation\\Source";
            var newFolderForTestCommand = "mkdir D:\\Automation\\Test";
            System.Diagnostics.ProcessStartInfo newFolderStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + newFolderForSourceCommand + "&" + newFolderForTestCommand);
            newFolderStartInfo.RedirectStandardOutput = true;
            newFolderStartInfo.UseShellExecute = false;

            Process newFolderProcess = new Process();
            newFolderProcess.StartInfo = newFolderStartInfo;
            newFolderProcess.Start();
            string newFolderResult = newFolderProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(newFolderResult);

            var sourceClonecommand = "git clone https://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@github.com/essential-studio/sfrating-xamarin.git";
            System.Diagnostics.ProcessStartInfo sourceCloneProcStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + sourceClonecommand);
            sourceCloneProcStartInfo.RedirectStandardOutput = true;
            sourceCloneProcStartInfo.UseShellExecute = false;
            sourceCloneProcStartInfo.WorkingDirectory = "D:\\Automation\\Source";

            Process sourceCloneProcess = new Process();
            sourceCloneProcess.StartInfo = sourceCloneProcStartInfo;
            sourceCloneProcess.Start();
            string sourceCloneResult = sourceCloneProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(sourceCloneResult);

            var switchBranchCommand = "git switch AutomationDev";
            System.Diagnostics.ProcessStartInfo switchBranchProcStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + switchBranchCommand);
            switchBranchProcStartInfo.RedirectStandardOutput = true;
            switchBranchProcStartInfo.UseShellExecute = false;
            switchBranchProcStartInfo.WorkingDirectory = "D:\\Automation\\Source\\sfrating-xamarin\\";

            Process switchBranchProcess = new Process();
            switchBranchProcess.StartInfo = switchBranchProcStartInfo;
            switchBranchProcess.Start();
            string switchBranchResult = switchBranchProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(switchBranchResult);

            Console.WriteLine("Source Compilation Start");
            var sourceCompileCommand = "powershell.exe -ExecutionPolicy ByPass -File build/build.ps1 -Script D:/Automation/Source/sfrating-xamarin/build/build.cake -Target build -OutputPath Assemblies -StudioVersion  20.3.1.1 -nugetserverurl http://nexus.syncfusion.com/repository/nuget-hosted/,https://api.nuget.org/v3/index.json";
            System.Diagnostics.ProcessStartInfo compileSourceProcStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + sourceCompileCommand);
            compileSourceProcStartInfo.RedirectStandardOutput = true;
            compileSourceProcStartInfo.UseShellExecute = false;
            compileSourceProcStartInfo.WorkingDirectory = "D:\\Automation\\Source\\sfrating-xamarin";

            Process compileSourceProcess = new Process();
            compileSourceProcess.StartInfo = compileSourceProcStartInfo;
            compileSourceProcess.Start();
            string compileSourceResult = compileSourceProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(compileSourceResult);

            Console.WriteLine("Source Compilation End");

            var testSourceClonecommand = "git clone https://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@github.com/essential-studio/sfrating-xamarin-tests.git";
            System.Diagnostics.ProcessStartInfo testSourceCloneProcStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + testSourceClonecommand);
            testSourceCloneProcStartInfo.RedirectStandardOutput = true;
            testSourceCloneProcStartInfo.UseShellExecute = false;
            testSourceCloneProcStartInfo.WorkingDirectory = "D:\\Automation\\Test\\";

            Process testSourceCloneProcess = new Process();
            testSourceCloneProcess.StartInfo = testSourceCloneProcStartInfo;
            testSourceCloneProcess.Start();
            string testSourceCloneResult = testSourceCloneProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(testSourceCloneResult);

            var testSourceSwitchBranchCommand = "git switch cloudAutomationTest_Dev";
            System.Diagnostics.ProcessStartInfo testSourceSwitchBranchProcStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + testSourceSwitchBranchCommand);
            testSourceSwitchBranchProcStartInfo.RedirectStandardOutput = true;
            testSourceSwitchBranchProcStartInfo.UseShellExecute = false;
            testSourceSwitchBranchProcStartInfo.WorkingDirectory = "D:\\Automation\\Test\\sfrating-xamarin-tests\\";

            Process testSourceSwitchBranchProcess = new Process();
            testSourceSwitchBranchProcess.StartInfo = testSourceSwitchBranchProcStartInfo;
            testSourceSwitchBranchProcess.Start();
            string testSourceSwitchBranchResult = testSourceSwitchBranchProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(testSourceSwitchBranchResult);

            Console.WriteLine("Test Compilation Start");
            var addEnvironmentMsBuildCommand = "set PATH=%PATH%;C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\BuildTools\\MSBuild\\Current\\Bin";
            var restoreProjectCommand = "msbuild /t:restore";
            var compileTestSourceCommand = "msbuild SfRatingSample.Android\\SfRatingSample.Android.csproj /verbosity:normal /t:Rebuild /t:PackageForAndroid /t:SignAndroidPackage /p:Configuration=Release";
            System.Diagnostics.ProcessStartInfo compileTestSourceProcStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + addEnvironmentMsBuildCommand + "&" + restoreProjectCommand + "&" + compileTestSourceCommand);
            compileTestSourceProcStartInfo.RedirectStandardOutput = true;
            compileTestSourceProcStartInfo.UseShellExecute = false;
            compileTestSourceProcStartInfo.WorkingDirectory = "D:\\Automation\\Test\\sfrating-xamarin-tests\\UITest\\XForms\\SfRatingSample\\";

            Process compileTestSourceProcess = new Process();
            compileTestSourceProcess.StartInfo = compileTestSourceProcStartInfo;
            compileTestSourceProcess.Start();
            string compileTestSourceResult = compileTestSourceProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(compileTestSourceResult);

            Console.WriteLine("Test Compilation End");

            Console.WriteLine("Install APK Start");
            var publishAPKCommand = "adb install com.companyname.sfratingsample-Signed.apk";
            System.Diagnostics.ProcessStartInfo publishAPKProcStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + publishAPKCommand);
            publishAPKProcStartInfo.RedirectStandardOutput = true;
            publishAPKProcStartInfo.UseShellExecute = false;
            publishAPKProcStartInfo.WorkingDirectory = "D:\\Automation\\Test\\sfrating-xamarin-tests\\UITest\\XForms\\SfRatingSample\\SfRatingSample.Android\\bin\\Release\\";

            Process publishAPKProcess = new Process();
            publishAPKProcess.StartInfo = publishAPKProcStartInfo;
            publishAPKProcess.Start();
            string publishAPKResult = publishAPKProcess.StandardOutput.ReadToEnd();
            Console.WriteLine(publishAPKResult);

            Console.WriteLine("Install APK Process End");
        }
    }
}



