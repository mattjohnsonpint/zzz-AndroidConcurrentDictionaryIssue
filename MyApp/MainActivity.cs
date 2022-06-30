using System.Collections;
using Android.OS;
using Android.Runtime;
using Java.Util;

namespace MyApp;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_main);
        
        
        // No issues constructing
        var myObject = new MyLib.MyObject();
        
        // No issues adding items
        myObject.SetData("a", "1");
        myObject.SetData("b", "2");
        myObject.SetData("c", "3");

        // No issues getting a single item by key
        var value = myObject.GetData("b");
        Console.WriteLine(value);

        // No issues retrieving the ConcurrentHashMap as a Dictionary
        var data = myObject.Data!;
        
        // Uncomment for workaround
        // if (Build.VERSION.SdkInt <= BuildVersionCodes.P)
        // {
        //     // Workaround by copying the ConcurrentHashMap to a HashMap.
        //     // Inefficient, but works if you only need one-time access to read the items.
        //     var map = new HashMap((IDictionary) data);
        //     data = new JavaDictionary<string, string>(map.Handle, JniHandleOwnership.DoNotRegister);
        // }

        // Iterating the items (without the workaround) will throw the following error on Android 9 ("Pie") and older (API 28)
        // Java.Lang.Error: no non-static method "Ljava/util/concurrent/ConcurrentHashMap$KeyIterator;.hasNext()Z"
        foreach (var item in data)
        {
            Console.WriteLine($"{item.Key} = {item.Value}");
        }
    }
}