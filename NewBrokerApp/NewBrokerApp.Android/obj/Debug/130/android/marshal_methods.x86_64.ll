; ModuleID = 'obj\Debug\130\android\marshal_methods.x86_64.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [490 x i64] [
	i64 2646484529726201, ; 0: FFImageLoading.Forms.Platform => 0x966f6b24c42f9 => 27
	i64 24362543149721218, ; 1: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 141
	i64 64035348636268546, ; 2: DevExpress.Xamarin.Android.Editors => 0xe37fcf70887802 => 14
	i64 120698629574877762, ; 3: Mono.Android => 0x1accec39cafe242 => 42
	i64 181099460066822533, ; 4: Microcharts.Droid.dll => 0x28364ffda4c4985 => 39
	i64 210515253464952879, ; 5: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 130
	i64 232391251801502327, ; 6: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 168
	i64 263803244706540312, ; 7: Rg.Plugins.Popup.dll => 0x3a937a743542b18 => 60
	i64 276473666272823710, ; 8: Xamarin.Forms.GoogleMaps => 0x3d63b55abf1099e => 192
	i64 295915112840604065, ; 9: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 169
	i64 316157742385208084, ; 10: Xamarin.AndroidX.Core.Core.Ktx.dll => 0x46337caa7dc1b14 => 135
	i64 347331204332682223, ; 11: ImageCircle.Forms.Plugin => 0x4d1f7e3dda87bef => 34
	i64 590536689428908136, ; 12: Xamarin.Android.Arch.Lifecycle.ViewModel.dll => 0x83201fd803ec868 => 90
	i64 634308326490598313, ; 13: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 153
	i64 684024108737575474, ; 14: Splat => 0x97e244d831b3a32 => 64
	i64 687654259221141486, ; 15: Xamarin.GooglePlayServices.Base => 0x98b09e7c92917ee => 206
	i64 702024105029695270, ; 16: System.Drawing.Common => 0x9be17343c0e7726 => 6
	i64 720058930071658100, ; 17: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 146
	i64 816102801403336439, ; 18: Xamarin.Android.Support.Collections => 0xb53612c89d8d6f7 => 94
	i64 846634227898301275, ; 19: Xamarin.Android.Arch.Lifecycle.LiveData.Core => 0xbbfd9583890bb5b => 87
	i64 872800313462103108, ; 20: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 140
	i64 887546508555532406, ; 21: Microcharts.Forms => 0xc5132d8dc173876 => 40
	i64 901995307004200655, ; 22: Plugin.FilePicker.dll => 0xc8487f3e70e06cf => 50
	i64 940822596282819491, ; 23: System.Transactions => 0xd0e792aa81923a3 => 222
	i64 964682803809979201, ; 24: Plugin.FilePicker.Abstractions.dll => 0xd633de622058b41 => 49
	i64 996343623809489702, ; 25: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 198
	i64 1000557547492888992, ; 26: Mono.Security.dll => 0xde2b1c9cba651a0 => 243
	i64 1120440138749646132, ; 27: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 203
	i64 1274477032785669217, ; 28: Splat.dll => 0x11afda1bdd956c61 => 64
	i64 1285447915151038934, ; 29: DevExpress.XamarinForms.Core.dll => 0x11d6d41177d819d6 => 20
	i64 1299368145264491196, ; 30: DevExpress.Xamarin.Android.Editors.dll => 0x120848719af2babc => 14
	i64 1315114680217950157, ; 31: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 124
	i64 1342439039765371018, ; 32: Xamarin.Android.Support.Fragment => 0x12a14d31b1d4d88a => 104
	i64 1400031058434376889, ; 33: Plugin.Permissions.dll => 0x136de8d4787ec4b9 => 55
	i64 1416135423712704079, ; 34: Microcharts => 0x13a71faa343e364f => 38
	i64 1425944114962822056, ; 35: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 7
	i64 1465843056802068477, ; 36: Xamarin.Firebase.Components.dll => 0x1457b87e6928f7fd => 182
	i64 1476839205573959279, ; 37: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 238
	i64 1490981186906623721, ; 38: Xamarin.Android.Support.VersionedParcelable => 0x14b1077d6c5c0ee9 => 117
	i64 1624659445732251991, ; 39: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 122
	i64 1628611045998245443, ; 40: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 155
	i64 1636321030536304333, ; 41: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 147
	i64 1731380447121279447, ; 42: Newtonsoft.Json => 0x18071957e9b889d7 => 45
	i64 1743969030606105336, ; 43: System.Memory.dll => 0x1833d297e88f2af8 => 244
	i64 1744702963312407042, ; 44: Xamarin.Android.Support.v7.AppCompat => 0x18366e19eeceb202 => 114
	i64 1795316252682057001, ; 45: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 123
	i64 1836611346387731153, ; 46: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 168
	i64 1837131419302612636, ; 47: Xamarin.Google.Android.DataTransport.TransportBackendCct.dll => 0x197ecd4ad53dce9c => 201
	i64 1860886102525309849, ; 48: Xamarin.Android.Support.v7.RecyclerView.dll => 0x19d3320d047b7399 => 115
	i64 1865037103900624886, ; 49: Microsoft.Bcl.AsyncInterfaces => 0x19e1f15d56eb87f6 => 41
	i64 1875917498431009007, ; 50: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 120
	i64 1918852405404808846, ; 51: Xamarin.AndroidX.AutoFill.dll => 0x1aa12218a08eb68e => 127
	i64 1938067011858688285, ; 52: Xamarin.Android.Support.v4.dll => 0x1ae565add0bd691d => 113
	i64 1981742497975770890, ; 53: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 154
	i64 1984538867944326539, ; 54: FFImageLoading.Platform.dll => 0x1b8a7f95fac7058b => 28
	i64 2040001226662520565, ; 55: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 242
	i64 2064708342624596306, ; 56: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x1ca7514c5eecb152 => 216
	i64 2076847052340733488, ; 57: Syncfusion.Core.XForms => 0x1cd27163f7962630 => 67
	i64 2133195048986300728, ; 58: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 45
	i64 2136356949452311481, ; 59: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 159
	i64 2137969380975227603, ; 60: PropertyChanged => 0x1dab97d315b0b2d3 => 57
	i64 2148470725164780602, ; 61: FFImageLoading.Svg.Forms => 0x1dd0e6bdcfc5cc3a => 29
	i64 2165725771938924357, ; 62: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 128
	i64 2231508185565011551, ; 63: Syncfusion.SfCalendar.XForms.Android => 0x1ef7e8df29fa9e5f => 69
	i64 2262844636196693701, ; 64: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 140
	i64 2284400282711631002, ; 65: System.Web.Services => 0x1fb3d1f42fd4249a => 226
	i64 2287887973817120656, ; 66: System.ComponentModel.DataAnnotations.dll => 0x1fc035fd8d41f790 => 227
	i64 2304837677853103545, ; 67: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0x1ffc6da80d5ed5b9 => 167
	i64 2329709569556905518, ; 68: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 150
	i64 2335503487726329082, ; 69: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 80
	i64 2337758774805907496, ; 70: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 78
	i64 2362316333598129966, ; 71: DevExpress.XamarinForms.Editors.Android => 0x20c8a23077383f2e => 21
	i64 2469392061734276978, ; 72: Syncfusion.Core.XForms.Android.dll => 0x22450aff2ad74f72 => 66
	i64 2470498323731680442, ; 73: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 134
	i64 2479423007379663237, ; 74: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 174
	i64 2489738558632930771, ; 75: Acr.UserDialogs.dll => 0x228d540722e8add3 => 9
	i64 2497223385847772520, ; 76: System.Runtime => 0x22a7eb7046413568 => 79
	i64 2541787113603107559, ; 77: Lottie.Android.dll => 0x23463de9b0fa8ae7 => 36
	i64 2547086958574651984, ; 78: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 119
	i64 2592350477072141967, ; 79: System.Xml.dll => 0x23f9e10627330e8f => 82
	i64 2624866290265602282, ; 80: mscorlib.dll => 0x246d65fbde2db8ea => 43
	i64 2694427813909235223, ; 81: Xamarin.AndroidX.Preference.dll => 0x256487d230fe0617 => 163
	i64 2783046991838674048, ; 82: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 78
	i64 2787234703088983483, ; 83: Xamarin.AndroidX.Startup.StartupRuntime => 0x26ae3f31ef429dbb => 170
	i64 2801558180824670388, ; 84: Plugin.CurrentActivity.dll => 0x26e1225279a4e0b4 => 48
	i64 2853437745093055792, ; 85: DevExpress.XamarinForms.CollectionView.Android => 0x27997282d0f69530 => 17
	i64 2863324215353042462, ; 86: FFImageLoading.Forms => 0x27bc92340ce4661e => 26
	i64 2949706848458024531, ; 87: Xamarin.Android.Support.SlidingPaneLayout => 0x28ef76c01de0a653 => 110
	i64 2960931600190307745, ; 88: Xamarin.Forms.Core => 0x2917579a49927da1 => 190
	i64 2977248461349026546, ; 89: Xamarin.Android.Support.DrawerLayout => 0x29514fb392c97af2 => 103
	i64 3017704767998173186, ; 90: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 203
	i64 3022227708164871115, ; 91: Xamarin.Android.Support.Media.Compat.dll => 0x29f11c168f8293cb => 108
	i64 3122911337338800527, ; 92: Microcharts.dll => 0x2b56cf50bf1e898f => 38
	i64 3171992396844006720, ; 93: Square.OkIO => 0x2c052e476c207d40 => 65
	i64 3260998928894807349, ; 94: Lottie.Forms.dll => 0x2d41653f91b44d35 => 37
	i64 3289520064315143713, ; 95: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 149
	i64 3303437397778967116, ; 96: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 121
	i64 3311221304742556517, ; 97: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 77
	i64 3321915913179469786, ; 98: NewBrokerApp.Android.dll => 0x2e19d0ec3ac797da => 1
	i64 3344514922410554693, ; 99: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 219
	i64 3355395775298280038, ; 100: Xamarin.AndroidX.AutoFill => 0x2e90c2ae13801a66 => 127
	i64 3364695309916733813, ; 101: Xamarin.Firebase.Common => 0x2eb1cc8eb5028175 => 181
	i64 3411255996856937470, ; 102: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 207
	i64 3493805808809882663, ; 103: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 172
	i64 3522470458906976663, ; 104: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 171
	i64 3531994851595924923, ; 105: System.Numerics => 0x31042a9aade235bb => 76
	i64 3571415421602489686, ; 106: System.Runtime.dll => 0x319037675df7e556 => 79
	i64 3596565917252612164, ; 107: Xamarin.Forms.OpenWhatsApp => 0x31e991a5751e7044 => 195
	i64 3609787854626478660, ; 108: Plugin.CurrentActivity => 0x32188aeda587da44 => 48
	i64 3633743434759698493, ; 109: DevExpress.XamarinForms.Charts => 0x326da666c9c2783d => 16
	i64 3716579019761409177, ; 110: netstandard.dll => 0x3393f0ed5c8c5c99 => 2
	i64 3727469159507183293, ; 111: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 166
	i64 3772598417116884899, ; 112: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 141
	i64 3936216335706411319, ; 113: Xamarin.Forms.GoogleMaps.dll => 0x36a03fe700ded137 => 192
	i64 3966267475168208030, ; 114: System.Memory => 0x370b03412596249e => 244
	i64 4201423742386704971, ; 115: Xamarin.AndroidX.Core.Core.Ktx => 0x3a4e74a233da124b => 135
	i64 4247996603072512073, ; 116: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 211
	i64 4252163538099460320, ; 117: Xamarin.Android.Support.ViewPager.dll => 0x3b02b8357f4958e0 => 118
	i64 4264996749430196783, ; 118: Xamarin.Android.Support.Transition.dll => 0x3b304ff259fb8a2f => 112
	i64 4335356748765836238, ; 119: Xamarin.Google.Android.DataTransport.TransportBackendCct => 0x3c2a47fe48c7b3ce => 201
	i64 4349341163892612332, ; 120: Xamarin.Android.Support.DocumentFile => 0x3c5bf6bea8cd9cec => 102
	i64 4416987920449902723, ; 121: Xamarin.Android.Support.AsyncLayoutInflater.dll => 0x3d4c4b1c879b9883 => 93
	i64 4500292229471022193, ; 122: Xamarin.Google.Dagger.dll => 0x3e743ff06b122c71 => 204
	i64 4525561845656915374, ; 123: System.ServiceModel.Internals => 0x3ece06856b710dae => 228
	i64 4636684751163556186, ; 124: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 176
	i64 4702770163853758138, ; 125: Xamarin.Firebase.Components => 0x4143988c34cf0eba => 182
	i64 4743821336939966868, ; 126: System.ComponentModel.Annotations => 0x41d5705f4239b194 => 3
	i64 4759461199762736555, ; 127: Xamarin.AndroidX.Lifecycle.Process.dll => 0x420d00be961cc5ab => 152
	i64 4782108999019072045, ; 128: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 126
	i64 4794310189461587505, ; 129: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 119
	i64 4795410492532947900, ; 130: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 171
	i64 4841234827713643511, ; 131: Xamarin.Android.Support.CoordinaterLayout => 0x432f856d041f03f7 => 96
	i64 4914391832395879945, ; 132: FFImageLoading.Transformations => 0x44336d5581099609 => 31
	i64 4963205065368577818, ; 133: Xamarin.Android.Support.LocalBroadcastManager.dll => 0x44e0d8b5f4b6a71a => 107
	i64 5081566143765835342, ; 134: System.Resources.ResourceManager.dll => 0x4685597c05d06e4e => 4
	i64 5099468265966638712, ; 135: System.Resources.ResourceManager => 0x46c4f35ea8519678 => 4
	i64 5142919913060024034, ; 136: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 197
	i64 5178572682164047940, ; 137: Xamarin.Android.Support.Print.dll => 0x47ddfc6acbee1044 => 109
	i64 5202753749449073649, ; 138: Plugin.Media => 0x4833e4f841be63f1 => 54
	i64 5203618020066742981, ; 139: Xamarin.Essentials => 0x4836f704f0e652c5 => 179
	i64 5205316157927637098, ; 140: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 157
	i64 5256995213548036366, ; 141: Xamarin.Forms.Maps.Android.dll => 0x48f4994b4175a10e => 193
	i64 5288341611614403055, ; 142: Xamarin.Android.Support.Interpolator.dll => 0x4963f6ad4b3179ef => 105
	i64 5325552317181266130, ; 143: NewBrokerApp.resources.dll => 0x49e8299dd25908d2 => 0
	i64 5348796042099802469, ; 144: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 158
	i64 5375264076663995773, ; 145: Xamarin.Forms.PancakeView => 0x4a98c632c779bd7d => 196
	i64 5376510917114486089, ; 146: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 174
	i64 5408338804355907810, ; 147: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 173
	i64 5439315836349573567, ; 148: Xamarin.Android.Support.Animated.Vector.Drawable.dll => 0x4b7c54ef36c5e9bf => 91
	i64 5446034149219586269, ; 149: System.Diagnostics.Debug => 0x4b94333452e150dd => 230
	i64 5451019430259338467, ; 150: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 133
	i64 5507995362134886206, ; 151: System.Core.dll => 0x4c705499688c873e => 72
	i64 5582653315569930024, ; 152: DevExpress.XamarinForms.CollectionView.Android.dll => 0x4d79919cc2b3cf28 => 17
	i64 5692067934154308417, ; 153: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 178
	i64 5757522595884336624, ; 154: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 131
	i64 5767696078500135884, ; 155: Xamarin.Android.Support.Annotations.dll => 0x500af9065b6a03cc => 92
	i64 5814345312393086621, ; 156: Xamarin.AndroidX.Preference => 0x50b0b44182a5c69d => 163
	i64 5896680224035167651, ; 157: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 151
	i64 6044705416426755068, ; 158: Xamarin.Android.Support.SwipeRefreshLayout.dll => 0x53e31b8ccdff13fc => 111
	i64 6085203216496545422, ; 159: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 198
	i64 6086316965293125504, ; 160: FormsViewGroup.dll => 0x5476f10882baef80 => 32
	i64 6092862891035488599, ; 161: Xamarin.Firebase.Measurement.Connector.dll => 0x548e32849d547157 => 188
	i64 6222399776351216807, ; 162: System.Text.Json.dll => 0x565a67a0ffe264a7 => 81
	i64 6276275310493285788, ; 163: Syncfusion.SfCalendar.XForms.dll => 0x5719cf244a81bd9c => 70
	i64 6300241346327543539, ; 164: Xamarin.Firebase.Iid => 0x576ef41fd714fef3 => 184
	i64 6311200438583329442, ; 165: Xamarin.Android.Support.LocalBroadcastManager => 0x5795e35c580c82a2 => 107
	i64 6319713645133255417, ; 166: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 153
	i64 6401687960814735282, ; 167: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 150
	i64 6405879832841858445, ; 168: Xamarin.Android.Support.Vector.Drawable.dll => 0x58e641c4a660ad8d => 116
	i64 6504860066809920875, ; 169: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 128
	i64 6548213210057960872, ; 170: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 138
	i64 6554405243736097249, ; 171: Xamarin.GooglePlayServices.Stats => 0x5af5ecd7aad901e1 => 210
	i64 6588599331800941662, ; 172: Xamarin.Android.Support.v4 => 0x5b6f682f335f045e => 113
	i64 6591024623626361694, ; 173: System.Web.Services.dll => 0x5b7805f9751a1b5e => 226
	i64 6659513131007730089, ; 174: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 146
	i64 6671798237668743565, ; 175: SkiaSharp => 0x5c96fd260152998d => 61
	i64 6799483249704623614, ; 176: NewBrokerApp => 0x5e5c9dfd8adcddfe => 44
	i64 6876862101832370452, ; 177: System.Xml.Linq => 0x5f6f85a57d108914 => 83
	i64 6878582369430612696, ; 178: Xamarin.Google.Android.DataTransport.TransportRuntime.dll => 0x5f75a238802d2ad8 => 202
	i64 6894844156784520562, ; 179: System.Numerics.Vectors => 0x5faf683aead1ad72 => 77
	i64 6975328107116786489, ; 180: Xamarin.Firebase.Annotations => 0x60cd57f4e07e7339 => 180
	i64 7026608356547306326, ; 181: Syncfusion.Core.XForms.dll => 0x618387125bcb2356 => 67
	i64 7036436454368433159, ; 182: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 148
	i64 7103753931438454322, ; 183: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 145
	i64 7111211609209905225, ; 184: Xamarin.Plugin.Calendar => 0x62b0194821972049 => 220
	i64 7141281584637745974, ; 185: Xamarin.GooglePlayServices.Maps.dll => 0x631aedc3dd5f1b36 => 209
	i64 7194160955514091247, ; 186: Xamarin.Android.Support.CursorAdapter.dll => 0x63d6cb45d266f6ef => 99
	i64 7270811800166795866, ; 187: System.Linq => 0x64e71ccf51a90a5a => 236
	i64 7330419912715392478, ; 188: Xamarin.Forms.GoogleMaps.Android => 0x65bae21287d9d5de => 191
	i64 7338192458477945005, ; 189: System.Reflection => 0x65d67f295d0740ad => 233
	i64 7364333345899356075, ; 190: DLToolkit.Forms.Controls.FlowListView => 0x66335e2901e51fab => 23
	i64 7385250113861300937, ; 191: Xamarin.Firebase.Iid.Interop.dll => 0x667dadd98e1db2c9 => 185
	i64 7403394698168553178, ; 192: Plugin.FilePicker.Abstractions => 0x66be2440cc58ceda => 49
	i64 7488575175965059935, ; 193: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 83
	i64 7489048572193775167, ; 194: System.ObjectModel => 0x67ee71ff6b419e3f => 232
	i64 7509866036550816153, ; 195: Plugin.FilePicker => 0x6838675f0b61d199 => 50
	i64 7594383334536821595, ; 196: DevExpress.Xamarin.Android.CollectionView.dll => 0x6964ab67ef36bb5b => 13
	i64 7608914158415257261, ; 197: DropdownMenu.dll => 0x69984b1d02c81ead => 24
	i64 7635363394907363464, ; 198: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 190
	i64 7637365915383206639, ; 199: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 179
	i64 7654504624184590948, ; 200: System.Net.Http => 0x6a3a4366801b8264 => 75
	i64 7735352534559001595, ; 201: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 215
	i64 7820441508502274321, ; 202: System.Data => 0x6c87ca1e14ff8111 => 221
	i64 7821246742157274664, ; 203: Xamarin.Android.Support.AsyncLayoutInflater => 0x6c8aa67926f72e28 => 93
	i64 7836164640616011524, ; 204: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 122
	i64 7875371864198757046, ; 205: AndHUD.dll => 0x6d4af0fc27ac3ab6 => 11
	i64 7879037620440914030, ; 206: Xamarin.Android.Support.v7.AppCompat.dll => 0x6d57f6f88a51d86e => 114
	i64 7904570928025870493, ; 207: Xamarin.Firebase.Installations => 0x6db2ad60fadca09d => 186
	i64 7927939710195668715, ; 208: SkiaSharp.Views.Android.dll => 0x6e05b32992ed16eb => 62
	i64 7940488133782528123, ; 209: Xamarin.GooglePlayServices.CloudMessaging => 0x6e3247e31d4fe07b => 208
	i64 7969431548154767168, ; 210: Xamarin.Firebase.Installations.dll => 0x6e991bc4e98e6740 => 186
	i64 8044118961405839122, ; 211: System.ComponentModel.Composition => 0x6fa2739369944712 => 225
	i64 8064050204834738623, ; 212: System.Collections.dll => 0x6fe942efa61731bf => 231
	i64 8083354569033831015, ; 213: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 149
	i64 8101777744205214367, ; 214: Xamarin.Android.Support.Annotations => 0x706f4beeec84729f => 92
	i64 8103644804370223335, ; 215: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 223
	i64 8113615946733131500, ; 216: System.Reflection.Extensions => 0x70995ab73cf916ec => 5
	i64 8132393369586336849, ; 217: Plugin.InputKit => 0x70dc10aeafef8451 => 53
	i64 8167236081217502503, ; 218: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 35
	i64 8185542183669246576, ; 219: System.Collections => 0x7198e33f4794aa70 => 231
	i64 8187102936927221770, ; 220: SkiaSharp.Views.Forms => 0x719e6ebe771ab80a => 63
	i64 8187640529827139739, ; 221: Xamarin.KotlinX.Coroutines.Android => 0x71a057ae90f0109b => 218
	i64 8196541262927413903, ; 222: Xamarin.Android.Support.Interpolator => 0x71bff6d9fb9ec28f => 105
	i64 8290740647658429042, ; 223: System.Runtime.Extensions => 0x730ea0b15c929a72 => 235
	i64 8318905602908530212, ; 224: System.ComponentModel.DataAnnotations => 0x7372b092055ea624 => 227
	i64 8385935383968044654, ; 225: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0x7460d3cd16cb566e => 89
	i64 8398329775253868912, ; 226: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 132
	i64 8400357532724379117, ; 227: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 162
	i64 8426919725312979251, ; 228: Xamarin.AndroidX.Lifecycle.Process => 0x74f26ed7aa033133 => 152
	i64 8428678171113854126, ; 229: Xamarin.Firebase.Iid.dll => 0x74f8ae23bb5494ae => 184
	i64 8465511506719290632, ; 230: Xamarin.Firebase.Messaging.dll => 0x757b89dcf7fc3508 => 189
	i64 8598790081731763592, ; 231: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x77550a055fc61d88 => 143
	i64 8601935802264776013, ; 232: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 173
	i64 8609060182490045521, ; 233: Square.OkIO.dll => 0x7779869f8b475c51 => 65
	i64 8626175481042262068, ; 234: Java.Interop => 0x77b654e585b55834 => 35
	i64 8639588376636138208, ; 235: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 161
	i64 8684531736582871431, ; 236: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 224
	i64 8711110225871910191, ; 237: DropdownMenu => 0x78e41498d45e352f => 24
	i64 8808820144457481518, ; 238: Xamarin.Android.Support.Loader.dll => 0x7a3f374010b17d2e => 106
	i64 8844506025403580595, ; 239: Plugin.FirebasePushNotification => 0x7abdff5eb1fb80b3 => 51
	i64 8853378295825400934, ; 240: Xamarin.Kotlin.StdLib.Common.dll => 0x7add84a720d38466 => 214
	i64 8917102979740339192, ; 241: Xamarin.Android.Support.DocumentFile.dll => 0x7bbfe9ea4d000bf8 => 102
	i64 8951477988056063522, ; 242: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0x7c3a09cd9ccf5e22 => 165
	i64 9072237425901999653, ; 243: RatingBarControl.dll => 0x7de70fdf40e49625 => 58
	i64 9114191852432800567, ; 244: FFImageLoading.dll => 0x7e7c1d3363043b37 => 25
	i64 9205382539026766386, ; 245: DevExpress.XamarinForms.Editors.dll => 0x7fc016a5a4461a32 => 22
	i64 9238306115887712111, ; 246: FFImageLoading.Forms.dll => 0x80350e773bce476f => 26
	i64 9312692141327339315, ; 247: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 178
	i64 9324707631942237306, ; 248: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 123
	i64 9439625609732276754, ; 249: Plugin.Connectivity.dll => 0x8300497a90c5c212 => 47
	i64 9475595603812259686, ; 250: Xamarin.Android.Support.Design => 0x838013ff707b9766 => 101
	i64 9584643793929893533, ; 251: System.IO.dll => 0x85037ebfbbd7f69d => 237
	i64 9659729154652888475, ; 252: System.Text.RegularExpressions => 0x860e407c9991dd9b => 240
	i64 9662334977499516867, ; 253: System.Numerics.dll => 0x8617827802b0cfc3 => 76
	i64 9678050649315576968, ; 254: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 134
	i64 9704315356731487263, ; 255: Plugin.FirebasePushNotification.dll => 0x86aca766ba59341f => 51
	i64 9711637524876806384, ; 256: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 158
	i64 9732461928540118312, ; 257: Plugin.Connectivity.Abstractions.dll => 0x8710a68f28a59d28 => 46
	i64 9774216967140627647, ; 258: Xamarin.Firebase.Datatransport.dll => 0x87a4fe8bac0354bf => 183
	i64 9780723996889434231, ; 259: AndHUD => 0x87bc1ca798bbc877 => 11
	i64 9796610708422913120, ; 260: Xamarin.Firebase.Iid.Interop => 0x87f48d88de55ec60 => 185
	i64 9808709177481450983, ; 261: Mono.Android.dll => 0x881f890734e555e7 => 42
	i64 9825649861376906464, ; 262: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 131
	i64 9834056768316610435, ; 263: System.Transactions.dll => 0x8879968718899783 => 222
	i64 9866412715007501892, ; 264: Xamarin.Android.Arch.Lifecycle.Common.dll => 0x88ec8a16fd6b6644 => 86
	i64 9875200773399460291, ; 265: Xamarin.GooglePlayServices.Base.dll => 0x890bc2c8482339c3 => 206
	i64 9907349773706910547, ; 266: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x897dfa20b758db53 => 143
	i64 9998632235833408227, ; 267: Mono.Security => 0x8ac2470b209ebae3 => 243
	i64 10038780035334861115, ; 268: System.Net.Http.dll => 0x8b50e941206af13b => 75
	i64 10226222362177979215, ; 269: Xamarin.Kotlin.StdLib.Jdk7 => 0x8dead70ebbc6434f => 216
	i64 10229024438826829339, ; 270: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 138
	i64 10303855825347935641, ; 271: Xamarin.Android.Support.Loader => 0x8efea647eeb3fd99 => 106
	i64 10321854143672141184, ; 272: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 213
	i64 10352330178246763130, ; 273: Xamarin.Firebase.Measurement.Connector => 0x8faadd72b7f4627a => 188
	i64 10360651442923773544, ; 274: System.Text.Encoding => 0x8fc86d98211c1e68 => 239
	i64 10363495123250631811, ; 275: Xamarin.Android.Support.Collections.dll => 0x8fd287e80cd8d483 => 94
	i64 10376576884623852283, ; 276: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 172
	i64 10406448008575299332, ; 277: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 219
	i64 10430153318873392755, ; 278: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 136
	i64 10447083246144586668, ; 279: Microsoft.Bcl.AsyncInterfaces.dll => 0x90fb7edc816203ac => 41
	i64 10549908655231907690, ; 280: Xamarin.Forms.OpenWhatsApp.dll => 0x9268ce06afeab76a => 195
	i64 10566960649245365243, ; 281: System.Globalization.dll => 0x92a562b96dcd13fb => 241
	i64 10634551425054932938, ; 282: DevExpress.Xamarin.Android.Charts.dll => 0x9395842d4405ffca => 12
	i64 10635644668885628703, ; 283: Xamarin.Android.Support.DrawerLayout.dll => 0x93996679ee34771f => 103
	i64 10653041769542411706, ; 284: DevExpress.XamarinForms.Editors.Android.dll => 0x93d7350c12f965ba => 21
	i64 10714184849103829812, ; 285: System.Runtime.Extensions.dll => 0x94b06e5aa4b4bb34 => 235
	i64 10775409704848971057, ; 286: Xamarin.Forms.Maps => 0x9589f20936d1d531 => 194
	i64 10785150219063592792, ; 287: System.Net.Primitives => 0x95ac8cfb68830758 => 238
	i64 10847732767863316357, ; 288: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 124
	i64 10850923258212604222, ; 289: Xamarin.Android.Arch.Lifecycle.Runtime => 0x9696393672c9593e => 89
	i64 10984620054693331049, ; 290: Plugin.InputKit.dll => 0x987135bda0a0c069 => 53
	i64 10988299007071641743, ; 291: HttpExtension.dll => 0x987e47ba7a48608f => 33
	i64 11023048688141570732, ; 292: System.Core => 0x98f9bc61168392ac => 72
	i64 11037814507248023548, ; 293: System.Xml => 0x992e31d0412bf7fc => 82
	i64 11039257436779699892, ; 294: Syncfusion.SfCalendar.XForms.Android.dll => 0x993352267757deb4 => 69
	i64 11162124722117608902, ; 295: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 177
	i64 11171845786728836392, ; 296: Xamarin.GooglePlayServices.CloudMessaging.dll => 0x9b0a5e8d536aad28 => 208
	i64 11201462017695523848, ; 297: FFImageLoading.Transformations.dll => 0x9b73965b71c5a408 => 31
	i64 11237162742616054720, ; 298: Polly => 0x9bf26bfa34e25bc0 => 56
	i64 11298161014952581172, ; 299: DevExpress.XamarinForms.Core.Android => 0x9ccb2195376a5834 => 19
	i64 11336891506707244397, ; 300: Xamarin.Firebase.Datatransport => 0x9d54bac28a6da56d => 183
	i64 11340910727871153756, ; 301: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 137
	i64 11376351552967644903, ; 302: Xamarin.Firebase.Annotations.dll => 0x9de0eb76829996e7 => 180
	i64 11376461258732682436, ; 303: Xamarin.Android.Support.Compat => 0x9de14f3d5fc13cc4 => 95
	i64 11392833485892708388, ; 304: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 164
	i64 11444370155346000636, ; 305: Xamarin.Forms.Maps.Android => 0x9ed292057b7afafc => 193
	i64 11529969570048099689, ; 306: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 177
	i64 11578238080964724296, ; 307: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 148
	i64 11580057168383206117, ; 308: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 120
	i64 11591352189662810718, ; 309: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0xa0dcc167234c525e => 170
	i64 11597940890313164233, ; 310: netstandard => 0xa0f429ca8d1805c9 => 2
	i64 11666126733838079721, ; 311: Xamarin.Plugin.Calendar.dll => 0xa1e66874631b56e9 => 220
	i64 11672361001936329215, ; 312: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 145
	i64 11743665907891708234, ; 313: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 229
	i64 11805766896659882188, ; 314: Plugin.Connectivity => 0xa3d68271607a60cc => 47
	i64 11834399401546345650, ; 315: Xamarin.Android.Support.SlidingPaneLayout.dll => 0xa43c3b8deb43ecb2 => 110
	i64 11855946309386773903, ; 316: Xamarin.Google.Dagger => 0xa488c85a571a258f => 204
	i64 11865714326292153359, ; 317: Xamarin.Android.Arch.Lifecycle.LiveData => 0xa4ab7c5000e8440f => 88
	i64 12102847907131387746, ; 318: System.Buffers => 0xa7f5f40c43256f62 => 71
	i64 12123043025855404482, ; 319: System.Reflection.Extensions.dll => 0xa83db366c0e359c2 => 5
	i64 12137774235383566651, ; 320: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 175
	i64 12145679461940342714, ; 321: System.Text.Json => 0xa88e1f1ebcb62fba => 81
	i64 12234076636015423288, ; 322: NewBrokerApp.Android => 0xa9c82be1ac9aef38 => 1
	i64 12346958216201575315, ; 323: Xamarin.JavaX.Inject.dll => 0xab593514a5491b93 => 212
	i64 12388767885335911387, ; 324: Xamarin.Android.Arch.Lifecycle.LiveData.dll => 0xabedbec0d236dbdb => 88
	i64 12414299427252656003, ; 325: Xamarin.Android.Support.Compat.dll => 0xac48738e28bad783 => 95
	i64 12451044538927396471, ; 326: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 144
	i64 12466513435562512481, ; 327: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 156
	i64 12487638416075308985, ; 328: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 139
	i64 12488608402635344228, ; 329: Lottie.Android => 0xad50732cba09c964 => 36
	i64 12501328358063843848, ; 330: Plugin.Geolocator.dll => 0xad7da3e822e9aa08 => 52
	i64 12538491095302438457, ; 331: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 129
	i64 12550732019250633519, ; 332: System.IO.Compression => 0xae2d28465e8e1b2f => 74
	i64 12700543734426720211, ; 333: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 130
	i64 12707502680607841355, ; 334: DevExpress.Xamarin.Android.Charts => 0xb05a1e5c5bf45c4b => 12
	i64 12708238894395270091, ; 335: System.IO => 0xb05cbbf17d3ba3cb => 237
	i64 12775743368198558629, ; 336: DevExpress.XamarinForms.Core => 0xb14c8ee7930713a5 => 20
	i64 12828192437253469131, ; 337: Xamarin.Kotlin.StdLib.Jdk8.dll => 0xb206e50e14d873cb => 217
	i64 12894151442605044929, ; 338: DevExpress.XamarinForms.Charts.dll => 0xb2f13a6bc09074c1 => 16
	i64 12900953504065120650, ; 339: DevExpress.Xamarin.Android.CollectionView => 0xb30964dc19a1e98a => 13
	i64 12928287693374593033, ; 340: RatingBarControl => 0xb36a8128fda59809 => 58
	i64 12952608645614506925, ; 341: Xamarin.Android.Support.Core.Utils => 0xb3c0e8eff48193ad => 98
	i64 12963446364377008305, ; 342: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 6
	i64 12993020259111397118, ; 343: NewBrokerApp.resources => 0xb4507b15efc9e6fe => 0
	i64 13129914918964716986, ; 344: Xamarin.AndroidX.Emoji2.dll => 0xb636d40db3fe65ba => 142
	i64 13146272124319258797, ; 345: Acr.Support.Android => 0xb670f0d85aab58ad => 8
	i64 13291835053457086558, ; 346: Xamarin.Forms.GoogleMaps.Android.dll => 0xb876158ed665185e => 191
	i64 13358059602087096138, ; 347: Xamarin.Android.Support.Fragment.dll => 0xb9615c6f1ee5af4a => 104
	i64 13370592475155966277, ; 348: System.Runtime.Serialization => 0xb98de304062ea945 => 7
	i64 13401370062847626945, ; 349: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 175
	i64 13403416310143541304, ; 350: Microcharts.Droid => 0xba02801ea6c86038 => 39
	i64 13404347523447273790, ; 351: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 132
	i64 13454009404024712428, ; 352: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 205
	i64 13465488254036897740, ; 353: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 215
	i64 13491513212026656886, ; 354: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 125
	i64 13492263892638604996, ; 355: SkiaSharp.Views.Forms.dll => 0xbb3e2686788d9ec4 => 63
	i64 13572454107664307259, ; 356: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 166
	i64 13622732128915678507, ; 357: Syncfusion.Core.XForms.Android => 0xbd0daab1e651e52b => 66
	i64 13643785327914841093, ; 358: Plugin.Media.dll => 0xbd587677c60cf405 => 54
	i64 13647894001087880694, ; 359: System.Data.dll => 0xbd670f48cb071df6 => 221
	i64 13828521679616088467, ; 360: Xamarin.Kotlin.StdLib.Common => 0xbfe8c733724e1993 => 214
	i64 13829530607229561650, ; 361: Xamarin.Firebase.Installations.InterOp => 0xbfec5cd0b64f6b32 => 187
	i64 13852575513600495870, ; 362: ImageCircle.Forms.Plugin.dll => 0xc03e3c09186e90fe => 34
	i64 13892556083635928008, ; 363: DevExpress.XamarinForms.Charts.Android.dll => 0xc0cc4626f34fbbc8 => 15
	i64 13959074834287824816, ; 364: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 144
	i64 13967638549803255703, ; 365: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 197
	i64 13970307180132182141, ; 366: Syncfusion.Licensing => 0xc1e0805ccade287d => 68
	i64 14030805823765547820, ; 367: PropertyChanged.dll => 0xc2b76f8eee070b2c => 57
	i64 14086899168879476927, ; 368: Acr.UserDialogs.Interface.dll => 0xc37eb82893ce80bf => 10
	i64 14092081194787758898, ; 369: HttpExtension => 0xc391212f01496332 => 33
	i64 14124974489674258913, ; 370: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 129
	i64 14125464355221830302, ; 371: System.Threading.dll => 0xc407bafdbc707a9e => 234
	i64 14161076099266624234, ; 372: Acr.UserDialogs => 0xc4863faf060fbaea => 9
	i64 14164783236351491542, ; 373: FFImageLoading.Svg.Platform.dll => 0xc4936b4e23237dd6 => 30
	i64 14168010648037233318, ; 374: DevExpress.XamarinForms.Charts.Android => 0xc49ee29e7a3612a6 => 15
	i64 14172845254133543601, ; 375: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 159
	i64 14252460695396124839, ; 376: FFImageLoading.Svg.Forms.dll => 0xc5cae97d5c4d88a7 => 29
	i64 14261073672896646636, ; 377: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 164
	i64 14327695147300244862, ; 378: System.Reflection.dll => 0xc6d632d338eb4d7e => 233
	i64 14369828458497533121, ; 379: Xamarin.Android.Support.Vector.Drawable => 0xc76be2d9300b64c1 => 116
	i64 14400856865250966808, ; 380: Xamarin.Android.Support.Core.UI => 0xc7da1f051a877d18 => 97
	i64 14438260825521943376, ; 381: RestSharp.dll => 0xc85f01b93fac7350 => 59
	i64 14486659737292545672, ; 382: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 151
	i64 14495724990987328804, ; 383: Xamarin.AndroidX.ResourceInspection.Annotation => 0xc92b2913e18d5d24 => 167
	i64 14524915121004231475, ; 384: Xamarin.JavaX.Inject => 0xc992dd58a4283b33 => 212
	i64 14538127318538747197, ; 385: Syncfusion.Licensing.dll => 0xc9c1cdc518e77d3d => 68
	i64 14551742072151931844, ; 386: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 80
	i64 14644440854989303794, ; 387: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 157
	i64 14661790646341542033, ; 388: Xamarin.Android.Support.SwipeRefreshLayout => 0xcb7924e94e552091 => 111
	i64 14775236863891732915, ; 389: DevExpress.XamarinForms.CollectionView.dll => 0xcd0c2fa52885f9b3 => 18
	i64 14789919016435397935, ; 390: Xamarin.Firebase.Common.dll => 0xcd4058fc2f6d352f => 181
	i64 14792063746108907174, ; 391: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 205
	i64 14809388726477333247, ; 392: Xamarin.GooglePlayServices.Stats.dll => 0xcd8584954e5b22ff => 210
	i64 14852515768018889994, ; 393: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 137
	i64 14987728460634540364, ; 394: System.IO.Compression.dll => 0xcfff1ba06622494c => 74
	i64 14988210264188246988, ; 395: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 139
	i64 15076659072870671916, ; 396: System.ObjectModel.dll => 0xd13b0d8c1620662c => 232
	i64 15133485256822086103, ; 397: System.Linq.dll => 0xd204f0a9127dd9d7 => 236
	i64 15150743910298169673, ; 398: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xd2424150783c3149 => 165
	i64 15188640517174936311, ; 399: Xamarin.Android.Arch.Core.Common => 0xd2c8e413d75142f7 => 84
	i64 15246441518555807158, ; 400: Xamarin.Android.Arch.Core.Common.dll => 0xd3963dc832493db6 => 84
	i64 15279429628684179188, ; 401: Xamarin.KotlinX.Coroutines.Android.dll => 0xd40b704b1c4c96f4 => 218
	i64 15326820765897713587, ; 402: Xamarin.Android.Arch.Core.Runtime.dll => 0xd4b3ce481769e7b3 => 85
	i64 15370334346939861994, ; 403: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 136
	i64 15398511348637731642, ; 404: FFImageLoading.Forms.Platform.dll => 0xd5b2807c9d5f8b3a => 27
	i64 15404322903526314552, ; 405: FFImageLoading.Svg.Platform => 0xd5c72610ae199238 => 30
	i64 15404781366499595240, ; 406: Syncfusion.SfCalendar.XForms => 0xd5c8c708e8c3d3e8 => 70
	i64 15418891414777631748, ; 407: Xamarin.Android.Support.Transition => 0xd5fae80c88241404 => 112
	i64 15457813392950723921, ; 408: Xamarin.Android.Support.Media.Compat => 0xd6852f61c31a8551 => 108
	i64 15526743539506359484, ; 409: System.Text.Encoding.dll => 0xd77a12fc26de2cbc => 239
	i64 15568534730848034786, ; 410: Xamarin.Android.Support.VersionedParcelable.dll => 0xd80e8bda21875fe2 => 117
	i64 15582737692548360875, ; 411: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 155
	i64 15609085926864131306, ; 412: System.dll => 0xd89e9cf3334914ea => 73
	i64 15777549416145007739, ; 413: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 169
	i64 15810740023422282496, ; 414: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 199
	i64 15817206913877585035, ; 415: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 229
	i64 15930129725311349754, ; 416: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 211
	i64 15963349826457351533, ; 417: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 242
	i64 16154507427712707110, ; 418: System => 0xe03056ea4e39aa26 => 73
	i64 16242842420508142678, ; 419: Xamarin.Android.Support.CoordinaterLayout.dll => 0xe16a2b1f8908ac56 => 96
	i64 16324796876805858114, ; 420: SkiaSharp.dll => 0xe28d5444586b6342 => 61
	i64 16355080029282893091, ; 421: DevExpress.XamarinForms.Core.Android.dll => 0xe2f8eaa23a7dfd23 => 19
	i64 16423015068819898779, ; 422: Xamarin.Kotlin.StdLib.Jdk8 => 0xe3ea453135e5c19b => 217
	i64 16427031961867955282, ; 423: NewBrokerApp.dll => 0xe3f88a890120ac52 => 44
	i64 16467346005009053642, ; 424: Xamarin.Google.Android.DataTransport.TransportApi => 0xe487c3f19e0337ca => 200
	i64 16471792842892863418, ; 425: DLToolkit.Forms.Controls.FlowListView.dll => 0xe4979051be7367ba => 23
	i64 16565028646146589191, ; 426: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 225
	i64 16621146507174665210, ; 427: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 133
	i64 16677317093839702854, ; 428: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 162
	i64 16767985610513713374, ; 429: Xamarin.Android.Arch.Core.Runtime => 0xe8b3da12798808de => 85
	i64 16822611501064131242, ; 430: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 223
	i64 16833383113903931215, ; 431: mscorlib => 0xe99c30c1484d7f4f => 43
	i64 16890310621557459193, ; 432: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 240
	i64 16895806301542741427, ; 433: Plugin.Permissions => 0xea79f6503d42f5b3 => 55
	i64 16932527889823454152, ; 434: Xamarin.Android.Support.Core.Utils.dll => 0xeafc6c67465253c8 => 98
	i64 17001062948826229159, ; 435: Microcharts.Forms.dll => 0xebefe8ad2cd7a9a7 => 40
	i64 17009591894298689098, ; 436: Xamarin.Android.Support.Animated.Vector.Drawable => 0xec0e35b50a097e4a => 91
	i64 17024911836938395553, ; 437: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 121
	i64 17031351772568316411, ; 438: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 160
	i64 17037200463775726619, ; 439: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 147
	i64 17053926018395002971, ; 440: Acr.Support.Android.dll => 0xecabb75bb039d85b => 8
	i64 17124705692820578889, ; 441: Lottie.Forms => 0xeda72d18d7ae2249 => 37
	i64 17151170952569239713, ; 442: RestSharp => 0xee05331c4de338a1 => 59
	i64 17187273293601214786, ; 443: System.ComponentModel.Annotations.dll => 0xee8575ff9aa89142 => 3
	i64 17238569155936077394, ; 444: Plugin.Connectivity.Abstractions => 0xef3bb3503f934652 => 46
	i64 17285063141349522879, ; 445: Rg.Plugins.Popup => 0xefe0e158cc55fdbf => 60
	i64 17328420479323385066, ; 446: DevExpress.XamarinForms.Editors => 0xf07aea9db4acacea => 22
	i64 17383232329670771222, ; 447: Xamarin.Android.Support.CustomView.dll => 0xf13da5b41a1cc216 => 100
	i64 17428701562824544279, ; 448: Xamarin.Android.Support.Core.UI.dll => 0xf1df2fbaec73d017 => 97
	i64 17434242208926550937, ; 449: Xamarin.Google.Android.DataTransport.TransportRuntime => 0xf1f2deeb1f304b99 => 202
	i64 17483646997724851973, ; 450: Xamarin.Android.Support.ViewPager => 0xf2a2644fe5b6ef05 => 118
	i64 17524135665394030571, ; 451: Xamarin.Android.Support.Print => 0xf3323c8a739097eb => 109
	i64 17544493274320527064, ; 452: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 126
	i64 17562678450496546059, ; 453: Acr.UserDialogs.Interface => 0xf3bb2affea41250b => 10
	i64 17627500474728259406, ; 454: System.Globalization => 0xf4a176498a351f4e => 241
	i64 17643123953373031521, ; 455: FFImageLoading => 0xf4d8f7c220fc2c61 => 25
	i64 17666959971718154066, ; 456: Xamarin.Android.Support.CustomView => 0xf52da67d9f4e4752 => 100
	i64 17671790519499593115, ; 457: SkiaSharp.Views.Android => 0xf53ecfd92be3959b => 62
	i64 17675249797910273188, ; 458: Polly.dll => 0xf54b1a0b30bc9ca4 => 56
	i64 17677828421478984182, ; 459: Xamarin.Firebase.Installations.InterOp.dll => 0xf5544349c68f29f6 => 187
	i64 17685921127322830888, ; 460: System.Diagnostics.Debug.dll => 0xf571038fafa74828 => 230
	i64 17704177640604968747, ; 461: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 156
	i64 17710060891934109755, ; 462: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 154
	i64 17760961058993581169, ; 463: Xamarin.Android.Arch.Lifecycle.Common => 0xf67b9bfb46dbac71 => 86
	i64 17786996386789405829, ; 464: Plugin.Geolocator => 0xf6d81af967bd3485 => 52
	i64 17816041456001989629, ; 465: Xamarin.Forms.Maps.dll => 0xf73f4b4f90a1bbfd => 194
	i64 17827832363535584534, ; 466: Xamarin.Forms.PancakeView.dll => 0xf7692f1427c04d16 => 196
	i64 17838668724098252521, ; 467: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 71
	i64 17841643939744178149, ; 468: Xamarin.Android.Arch.Lifecycle.ViewModel => 0xf79a40a25573dfe5 => 90
	i64 17866241960153083370, ; 469: DevExpress.XamarinForms.CollectionView => 0xf7f1a467421a6dea => 18
	i64 17882897186074144999, ; 470: FormsViewGroup => 0xf82cd03e3ac830e7 => 32
	i64 17891337867145587222, ; 471: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 213
	i64 17892495832318972303, ; 472: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 199
	i64 17928294245072900555, ; 473: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 224
	i64 17936749993673010118, ; 474: Xamarin.Android.Support.Design.dll => 0xf8ec231615deabc6 => 101
	i64 17945795017270165205, ; 475: Xamarin.Google.Android.DataTransport.TransportApi.dll => 0xf90c457cc05cfed5 => 200
	i64 17947624217716767869, ; 476: FFImageLoading.Platform => 0xf912c522ab34bc7d => 28
	i64 17958105683855786126, ; 477: Xamarin.Android.Arch.Lifecycle.LiveData.Core.dll => 0xf93801f92d25c08e => 87
	i64 17969331831154222830, ; 478: Xamarin.GooglePlayServices.Maps => 0xf95fe418471126ee => 209
	i64 17986907704309214542, ; 479: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 207
	i64 18025913125965088385, ; 480: System.Threading => 0xfa28e87b91334681 => 234
	i64 18090425465832348288, ; 481: Xamarin.Android.Support.v7.RecyclerView => 0xfb0e1a1d2e9e1a80 => 115
	i64 18116111925905154859, ; 482: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 125
	i64 18121036031235206392, ; 483: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 160
	i64 18129453464017766560, ; 484: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 228
	i64 18260797123374478311, ; 485: Xamarin.AndroidX.Emoji2 => 0xfd6b623bde35f3e7 => 142
	i64 18301997741680159453, ; 486: Xamarin.Android.Support.CursorAdapter => 0xfdfdc1fa58d8eadd => 99
	i64 18305135509493619199, ; 487: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 161
	i64 18337470502355292274, ; 488: Xamarin.Firebase.Messaging => 0xfe7bc8440c175072 => 189
	i64 18380184030268848184 ; 489: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 176
], align 16
@assembly_image_cache_indices = local_unnamed_addr constant [490 x i32] [
	i32 27, i32 141, i32 14, i32 42, i32 39, i32 130, i32 168, i32 60, ; 0..7
	i32 192, i32 169, i32 135, i32 34, i32 90, i32 153, i32 64, i32 206, ; 8..15
	i32 6, i32 146, i32 94, i32 87, i32 140, i32 40, i32 50, i32 222, ; 16..23
	i32 49, i32 198, i32 243, i32 203, i32 64, i32 20, i32 14, i32 124, ; 24..31
	i32 104, i32 55, i32 38, i32 7, i32 182, i32 238, i32 117, i32 122, ; 32..39
	i32 155, i32 147, i32 45, i32 244, i32 114, i32 123, i32 168, i32 201, ; 40..47
	i32 115, i32 41, i32 120, i32 127, i32 113, i32 154, i32 28, i32 242, ; 48..55
	i32 216, i32 67, i32 45, i32 159, i32 57, i32 29, i32 128, i32 69, ; 56..63
	i32 140, i32 226, i32 227, i32 167, i32 150, i32 80, i32 78, i32 21, ; 64..71
	i32 66, i32 134, i32 174, i32 9, i32 79, i32 36, i32 119, i32 82, ; 72..79
	i32 43, i32 163, i32 78, i32 170, i32 48, i32 17, i32 26, i32 110, ; 80..87
	i32 190, i32 103, i32 203, i32 108, i32 38, i32 65, i32 37, i32 149, ; 88..95
	i32 121, i32 77, i32 1, i32 219, i32 127, i32 181, i32 207, i32 172, ; 96..103
	i32 171, i32 76, i32 79, i32 195, i32 48, i32 16, i32 2, i32 166, ; 104..111
	i32 141, i32 192, i32 244, i32 135, i32 211, i32 118, i32 112, i32 201, ; 112..119
	i32 102, i32 93, i32 204, i32 228, i32 176, i32 182, i32 3, i32 152, ; 120..127
	i32 126, i32 119, i32 171, i32 96, i32 31, i32 107, i32 4, i32 4, ; 128..135
	i32 197, i32 109, i32 54, i32 179, i32 157, i32 193, i32 105, i32 0, ; 136..143
	i32 158, i32 196, i32 174, i32 173, i32 91, i32 230, i32 133, i32 72, ; 144..151
	i32 17, i32 178, i32 131, i32 92, i32 163, i32 151, i32 111, i32 198, ; 152..159
	i32 32, i32 188, i32 81, i32 70, i32 184, i32 107, i32 153, i32 150, ; 160..167
	i32 116, i32 128, i32 138, i32 210, i32 113, i32 226, i32 146, i32 61, ; 168..175
	i32 44, i32 83, i32 202, i32 77, i32 180, i32 67, i32 148, i32 145, ; 176..183
	i32 220, i32 209, i32 99, i32 236, i32 191, i32 233, i32 23, i32 185, ; 184..191
	i32 49, i32 83, i32 232, i32 50, i32 13, i32 24, i32 190, i32 179, ; 192..199
	i32 75, i32 215, i32 221, i32 93, i32 122, i32 11, i32 114, i32 186, ; 200..207
	i32 62, i32 208, i32 186, i32 225, i32 231, i32 149, i32 92, i32 223, ; 208..215
	i32 5, i32 53, i32 35, i32 231, i32 63, i32 218, i32 105, i32 235, ; 216..223
	i32 227, i32 89, i32 132, i32 162, i32 152, i32 184, i32 189, i32 143, ; 224..231
	i32 173, i32 65, i32 35, i32 161, i32 224, i32 24, i32 106, i32 51, ; 232..239
	i32 214, i32 102, i32 165, i32 58, i32 25, i32 22, i32 26, i32 178, ; 240..247
	i32 123, i32 47, i32 101, i32 237, i32 240, i32 76, i32 134, i32 51, ; 248..255
	i32 158, i32 46, i32 183, i32 11, i32 185, i32 42, i32 131, i32 222, ; 256..263
	i32 86, i32 206, i32 143, i32 243, i32 75, i32 216, i32 138, i32 106, ; 264..271
	i32 213, i32 188, i32 239, i32 94, i32 172, i32 219, i32 136, i32 41, ; 272..279
	i32 195, i32 241, i32 12, i32 103, i32 21, i32 235, i32 194, i32 238, ; 280..287
	i32 124, i32 89, i32 53, i32 33, i32 72, i32 82, i32 69, i32 177, ; 288..295
	i32 208, i32 31, i32 56, i32 19, i32 183, i32 137, i32 180, i32 95, ; 296..303
	i32 164, i32 193, i32 177, i32 148, i32 120, i32 170, i32 2, i32 220, ; 304..311
	i32 145, i32 229, i32 47, i32 110, i32 204, i32 88, i32 71, i32 5, ; 312..319
	i32 175, i32 81, i32 1, i32 212, i32 88, i32 95, i32 144, i32 156, ; 320..327
	i32 139, i32 36, i32 52, i32 129, i32 74, i32 130, i32 12, i32 237, ; 328..335
	i32 20, i32 217, i32 16, i32 13, i32 58, i32 98, i32 6, i32 0, ; 336..343
	i32 142, i32 8, i32 191, i32 104, i32 7, i32 175, i32 39, i32 132, ; 344..351
	i32 205, i32 215, i32 125, i32 63, i32 166, i32 66, i32 54, i32 221, ; 352..359
	i32 214, i32 187, i32 34, i32 15, i32 144, i32 197, i32 68, i32 57, ; 360..367
	i32 10, i32 33, i32 129, i32 234, i32 9, i32 30, i32 15, i32 159, ; 368..375
	i32 29, i32 164, i32 233, i32 116, i32 97, i32 59, i32 151, i32 167, ; 376..383
	i32 212, i32 68, i32 80, i32 157, i32 111, i32 18, i32 181, i32 205, ; 384..391
	i32 210, i32 137, i32 74, i32 139, i32 232, i32 236, i32 165, i32 84, ; 392..399
	i32 84, i32 218, i32 85, i32 136, i32 27, i32 30, i32 70, i32 112, ; 400..407
	i32 108, i32 239, i32 117, i32 155, i32 73, i32 169, i32 199, i32 229, ; 408..415
	i32 211, i32 242, i32 73, i32 96, i32 61, i32 19, i32 217, i32 44, ; 416..423
	i32 200, i32 23, i32 225, i32 133, i32 162, i32 85, i32 223, i32 43, ; 424..431
	i32 240, i32 55, i32 98, i32 40, i32 91, i32 121, i32 160, i32 147, ; 432..439
	i32 8, i32 37, i32 59, i32 3, i32 46, i32 60, i32 22, i32 100, ; 440..447
	i32 97, i32 202, i32 118, i32 109, i32 126, i32 10, i32 241, i32 25, ; 448..455
	i32 100, i32 62, i32 56, i32 187, i32 230, i32 156, i32 154, i32 86, ; 456..463
	i32 52, i32 194, i32 196, i32 71, i32 90, i32 18, i32 32, i32 213, ; 464..471
	i32 199, i32 224, i32 101, i32 200, i32 28, i32 87, i32 209, i32 207, ; 472..479
	i32 234, i32 115, i32 125, i32 160, i32 228, i32 142, i32 99, i32 161, ; 480..487
	i32 189, i32 176 ; 488..489
], align 16

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 16; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1}
!llvm.ident = !{!2}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
