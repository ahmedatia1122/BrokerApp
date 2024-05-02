; ModuleID = 'obj\Debug\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [490 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 153
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 205
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 45
	i32 39852199, ; 3: Plugin.Permissions => 0x26018a7 => 55
	i32 57263871, ; 4: Xamarin.Forms.Core.dll => 0x369c6ff => 190
	i32 57967248, ; 5: Xamarin.Android.Support.VersionedParcelable.dll => 0x3748290 => 117
	i32 88799905, ; 6: Acr.UserDialogs => 0x54afaa1 => 9
	i32 99966887, ; 7: Xamarin.Firebase.Iid.dll => 0x5f55fa7 => 184
	i32 101534019, ; 8: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 169
	i32 103834273, ; 9: Xamarin.Firebase.Annotations.dll => 0x63062a1 => 180
	i32 120558881, ; 10: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 169
	i32 134690465, ; 11: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 216
	i32 148395041, ; 12: Lottie.Forms.dll => 0x8d85421 => 37
	i32 159306688, ; 13: System.ComponentModel.Annotations => 0x97ed3c0 => 3
	i32 160529393, ; 14: Xamarin.Android.Arch.Core.Common => 0x9917bf1 => 84
	i32 165246403, ; 15: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 130
	i32 166922606, ; 16: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 95
	i32 182336117, ; 17: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 171
	i32 201930040, ; 18: Xamarin.Android.Arch.Core.Runtime => 0xc093538 => 85
	i32 209399409, ; 19: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 128
	i32 212497893, ; 20: Xamarin.Forms.Maps.Android => 0xcaa75e5 => 193
	i32 219130465, ; 21: Xamarin.Android.Support.v4 => 0xd0faa61 => 113
	i32 220171995, ; 22: System.Diagnostics.Debug => 0xd1f8edb => 230
	i32 230216969, ; 23: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 147
	i32 231814094, ; 24: System.Globalization => 0xdd133ce => 241
	i32 232815796, ; 25: System.Web.Services => 0xde07cb4 => 226
	i32 261689757, ; 26: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 133
	i32 278686392, ; 27: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 151
	i32 280482487, ; 28: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 145
	i32 293914992, ; 29: Xamarin.Android.Support.Transition => 0x1184c970 => 112
	i32 318968648, ; 30: Xamarin.AndroidX.Activity.dll => 0x13031348 => 119
	i32 319314094, ; 31: Xamarin.Forms.Maps => 0x130858ae => 194
	i32 321597661, ; 32: System.Numerics => 0x132b30dd => 76
	i32 342366114, ; 33: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 149
	i32 350319310, ; 34: NewBrokerApp.Android.dll => 0x14e172ce => 1
	i32 365417495, ; 35: NewBrokerApp.dll => 0x15c7d417 => 44
	i32 385762202, ; 36: System.Memory.dll => 0x16fe439a => 244
	i32 388313361, ; 37: Xamarin.Android.Support.Animated.Vector.Drawable => 0x17253111 => 91
	i32 389971796, ; 38: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 97
	i32 402672763, ; 39: Xamarin.Plugin.Calendar => 0x18004c7b => 220
	i32 441335492, ; 40: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 132
	i32 442521989, ; 41: Xamarin.Essentials => 0x1a605985 => 179
	i32 442565967, ; 42: System.Collections => 0x1a61054f => 231
	i32 450948140, ; 43: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 144
	i32 465846621, ; 44: mscorlib => 0x1bc4415d => 43
	i32 469710990, ; 45: System.dll => 0x1bff388e => 73
	i32 476646585, ; 46: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 145
	i32 485140951, ; 47: Xamarin.Google.Android.DataTransport.TransportRuntime => 0x1ceaa9d7 => 202
	i32 486930444, ; 48: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 157
	i32 495452658, ; 49: Xamarin.Google.Android.DataTransport.TransportRuntime.dll => 0x1d8801f2 => 202
	i32 498788369, ; 50: System.ObjectModel => 0x1dbae811 => 232
	i32 507148113, ; 51: Xamarin.Google.Android.DataTransport.TransportApi.dll => 0x1e3a7751 => 200
	i32 514659665, ; 52: Xamarin.Android.Support.Compat => 0x1ead1551 => 95
	i32 520798577, ; 53: FFImageLoading.Platform => 0x1f0ac171 => 28
	i32 524864063, ; 54: Xamarin.Android.Support.Print => 0x1f48ca3f => 109
	i32 525008092, ; 55: SkiaSharp.dll => 0x1f4afcdc => 61
	i32 526420162, ; 56: System.Transactions.dll => 0x1f6088c2 => 222
	i32 527452488, ; 57: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 216
	i32 539750087, ; 58: Xamarin.Android.Support.Design => 0x202beec7 => 101
	i32 542030372, ; 59: Xamarin.GooglePlayServices.Stats => 0x204eba24 => 210
	i32 545304856, ; 60: System.Runtime.Extensions => 0x2080b118 => 235
	i32 548916678, ; 61: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 41
	i32 553090349, ; 62: DevExpress.XamarinForms.Charts.Android => 0x20f77d2d => 15
	i32 571524804, ; 63: Xamarin.Android.Support.v7.RecyclerView => 0x2210c6c4 => 115
	i32 581545823, ; 64: FFImageLoading.Svg.Forms => 0x22a9af5f => 29
	i32 605376203, ; 65: System.IO.Compression.FileSystem => 0x24154ecb => 224
	i32 627609679, ; 66: Xamarin.AndroidX.CustomView => 0x2568904f => 138
	i32 639843206, ; 67: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 143
	i32 662205335, ; 68: System.Text.Encodings.Web.dll => 0x27787397 => 80
	i32 663517072, ; 69: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 176
	i32 666292255, ; 70: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 124
	i32 679820142, ; 71: Plugin.Connectivity.Abstractions => 0x28853b6e => 46
	i32 690569205, ; 72: System.Xml.Linq.dll => 0x29293ff5 => 83
	i32 691348768, ; 73: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 218
	i32 691439157, ; 74: Acr.UserDialogs.dll => 0x29368635 => 9
	i32 692692150, ; 75: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 92
	i32 698030881, ; 76: FFImageLoading.Transformations => 0x299b1b21 => 31
	i32 700284507, ; 77: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 213
	i32 719061231, ; 78: Syncfusion.Core.XForms.dll => 0x2adc00ef => 67
	i32 720511267, ; 79: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 217
	i32 775507847, ; 80: System.IO.Compression => 0x2e394f87 => 74
	i32 791272004, ; 81: Plugin.InputKit => 0x2f29da44 => 53
	i32 791612551, ; 82: DLToolkit.Forms.Controls.FlowListView => 0x2f2f0c87 => 23
	i32 801787702, ; 83: Xamarin.Android.Support.Interpolator => 0x2fca4f36 => 105
	i32 809851609, ; 84: System.Drawing.Common.dll => 0x30455ad9 => 6
	i32 834129013, ; 85: NewBrokerApp.resources.dll => 0x31b7cc75 => 0
	i32 843511501, ; 86: Xamarin.AndroidX.Print => 0x3246f6cd => 164
	i32 843871832, ; 87: FFImageLoading.Svg.Forms.dll => 0x324c7658 => 29
	i32 846667644, ; 88: Xamarin.Firebase.Installations.dll => 0x32771f7c => 186
	i32 877678880, ; 89: System.Globalization.dll => 0x34505120 => 241
	i32 882434999, ; 90: Xamarin.Firebase.Installations.InterOp.dll => 0x3498e3b7 => 187
	i32 882883187, ; 91: Xamarin.Android.Support.v4.dll => 0x349fba73 => 113
	i32 886248193, ; 92: Microcharts.Droid => 0x34d31301 => 39
	i32 902159924, ; 93: Rg.Plugins.Popup => 0x35c5de34 => 60
	i32 916714535, ; 94: Xamarin.Android.Support.Print.dll => 0x36a3f427 => 109
	i32 928116545, ; 95: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 205
	i32 936632277, ; 96: DevExpress.XamarinForms.CollectionView => 0x37d3dfd5 => 18
	i32 955402788, ; 97: Newtonsoft.Json => 0x38f24a24 => 45
	i32 956575887, ; 98: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 217
	i32 957807352, ; 99: Plugin.CurrentActivity => 0x3916faf8 => 48
	i32 958213972, ; 100: Xamarin.Android.Support.Media.Compat => 0x391d2f54 => 108
	i32 961995525, ; 101: Square.OkIO.dll => 0x3956e305 => 65
	i32 967690846, ; 102: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 149
	i32 974778368, ; 103: FormsViewGroup.dll => 0x3a19f000 => 32
	i32 987342438, ; 104: Xamarin.Android.Arch.Lifecycle.LiveData.dll => 0x3ad9a666 => 88
	i32 992768348, ; 105: System.Collections.dll => 0x3b2c715c => 231
	i32 996733531, ; 106: Xamarin.Google.Android.DataTransport.TransportBackendCct => 0x3b68f25b => 201
	i32 1012816738, ; 107: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 168
	i32 1035644815, ; 108: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 123
	i32 1036359102, ; 109: Xamarin.GooglePlayServices.CloudMessaging.dll => 0x3dc595be => 208
	i32 1042160112, ; 110: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 198
	i32 1052210849, ; 111: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 154
	i32 1084122840, ; 112: Xamarin.Kotlin.StdLib => 0x409e66d8 => 215
	i32 1098167829, ; 113: Xamarin.Android.Arch.Lifecycle.ViewModel => 0x4174b615 => 90
	i32 1098259244, ; 114: System => 0x41761b2c => 73
	i32 1104002344, ; 115: Plugin.Media => 0x41cdbd28 => 54
	i32 1113689558, ; 116: Acr.Support.Android => 0x42618dd6 => 8
	i32 1127295045, ; 117: Polly.dll => 0x43312845 => 56
	i32 1137654822, ; 118: Plugin.Permissions.dll => 0x43cf3c26 => 55
	i32 1141947663, ; 119: Xamarin.Firebase.Measurement.Connector.dll => 0x4410bd0f => 188
	i32 1175144683, ; 120: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 174
	i32 1178241025, ; 121: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 161
	i32 1179022490, ; 122: Plugin.FilePicker => 0x4646749a => 50
	i32 1204270330, ; 123: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 124
	i32 1244231028, ; 124: HttpExtension => 0x4a297574 => 33
	i32 1264511973, ; 125: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 170
	i32 1267360935, ; 126: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 175
	i32 1271249867, ; 127: Plugin.FilePicker.dll => 0x4bc5bbcb => 50
	i32 1275534314, ; 128: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 218
	i32 1282958517, ; 129: Plugin.Geolocator => 0x4c7864b5 => 52
	i32 1283555170, ; 130: Xamarin.Forms.OpenWhatsApp.dll => 0x4c817f62 => 195
	i32 1292763917, ; 131: Xamarin.Android.Support.CursorAdapter.dll => 0x4d0e030d => 99
	i32 1293217323, ; 132: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 140
	i32 1297413738, ; 133: Xamarin.Android.Arch.Lifecycle.LiveData.Core => 0x4d54f66a => 87
	i32 1309284514, ; 134: Plugin.FirebasePushNotification => 0x4e0a18a2 => 51
	i32 1312708447, ; 135: Acr.UserDialogs.Interface.dll => 0x4e3e575f => 10
	i32 1324164729, ; 136: System.Linq => 0x4eed2679 => 236
	i32 1333047053, ; 137: Xamarin.Firebase.Common => 0x4f74af0d => 181
	i32 1354490624, ; 138: Xamarin.Forms.GoogleMaps.dll => 0x50bbe300 => 192
	i32 1359785034, ; 139: Xamarin.Android.Support.Design.dll => 0x510cac4a => 101
	i32 1364015309, ; 140: System.IO => 0x514d38cd => 237
	i32 1365406463, ; 141: System.ServiceModel.Internals.dll => 0x516272ff => 228
	i32 1371845985, ; 142: Xamarin.Forms.GoogleMaps.Android => 0x51c4b561 => 191
	i32 1376866003, ; 143: Xamarin.AndroidX.SavedState => 0x52114ed3 => 168
	i32 1379779777, ; 144: System.Resources.ResourceManager => 0x523dc4c1 => 4
	i32 1379897097, ; 145: Xamarin.JavaX.Inject => 0x523f8f09 => 212
	i32 1395857551, ; 146: Xamarin.AndroidX.Media.dll => 0x5333188f => 158
	i32 1406073936, ; 147: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 134
	i32 1411638395, ; 148: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 78
	i32 1445445088, ; 149: Xamarin.Android.Support.Fragment => 0x5627bde0 => 104
	i32 1451498148, ; 150: DevExpress.XamarinForms.Core.dll => 0x56841aa4 => 20
	i32 1455166989, ; 151: DevExpress.Xamarin.Android.CollectionView.dll => 0x56bc160d => 13
	i32 1457743152, ; 152: System.Runtime.Extensions.dll => 0x56e36530 => 235
	i32 1460219004, ; 153: Xamarin.Forms.Xaml => 0x57092c7c => 199
	i32 1462112819, ; 154: System.IO.Compression.dll => 0x57261233 => 74
	i32 1469204771, ; 155: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 122
	i32 1516315406, ; 156: Syncfusion.Core.XForms.Android.dll => 0x5a61230e => 66
	i32 1516649851, ; 157: Xamarin.Forms.OpenWhatsApp => 0x5a663d7b => 195
	i32 1530663695, ; 158: Xamarin.Forms.Maps.dll => 0x5b3c130f => 194
	i32 1530772511, ; 159: FFImageLoading.Forms.Platform => 0x5b3dbc1f => 27
	i32 1531040989, ; 160: Xamarin.Firebase.Iid.Interop.dll => 0x5b41d4dd => 185
	i32 1543031311, ; 161: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 240
	i32 1550322496, ; 162: System.Reflection.Extensions.dll => 0x5c680b40 => 5
	i32 1574652163, ; 163: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 98
	i32 1581342938, ; 164: DevExpress.XamarinForms.Core.Android.dll => 0x5e4160da => 19
	i32 1582372066, ; 165: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 139
	i32 1582526884, ; 166: Microcharts.Forms.dll => 0x5e5371a4 => 40
	i32 1587300192, ; 167: DevExpress.XamarinForms.Editors => 0x5e9c4760 => 22
	i32 1587447679, ; 168: Xamarin.Android.Arch.Core.Common.dll => 0x5e9e877f => 84
	i32 1592978981, ; 169: System.Runtime.Serialization.dll => 0x5ef2ee25 => 7
	i32 1603222957, ; 170: Syncfusion.SfCalendar.XForms.Android => 0x5f8f3dad => 69
	i32 1622152042, ; 171: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 156
	i32 1624863272, ; 172: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 178
	i32 1635184631, ; 173: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 143
	i32 1635482189, ; 174: FFImageLoading.Transformations.dll => 0x617b7a4d => 31
	i32 1636350590, ; 175: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 137
	i32 1639515021, ; 176: System.Net.Http.dll => 0x61b9038d => 75
	i32 1639986890, ; 177: System.Text.RegularExpressions => 0x61c036ca => 240
	i32 1657153582, ; 178: System.Runtime => 0x62c6282e => 79
	i32 1658241508, ; 179: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 172
	i32 1658251792, ; 180: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 203
	i32 1658523326, ; 181: DevExpress.XamarinForms.Charts => 0x62db0ebe => 16
	i32 1662014763, ; 182: Xamarin.Android.Support.Vector.Drawable => 0x6310552b => 116
	i32 1670060433, ; 183: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 133
	i32 1677501392, ; 184: System.Net.Primitives.dll => 0x63fca3d0 => 238
	i32 1698840827, ; 185: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 214
	i32 1701541528, ; 186: System.Diagnostics.Debug.dll => 0x656b7698 => 230
	i32 1722051300, ; 187: SkiaSharp.Views.Forms => 0x66a46ae4 => 63
	i32 1726116996, ; 188: System.Reflection.dll => 0x66e27484 => 233
	i32 1729485958, ; 189: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 129
	i32 1765942094, ; 190: System.Reflection.Extensions => 0x6942234e => 5
	i32 1766324549, ; 191: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 171
	i32 1776026572, ; 192: System.Core.dll => 0x69dc03cc => 72
	i32 1788241197, ; 193: Xamarin.AndroidX.Fragment => 0x6a96652d => 144
	i32 1793089559, ; 194: FFImageLoading.Forms.dll => 0x6ae06017 => 26
	i32 1796167890, ; 195: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 41
	i32 1808609942, ; 196: Xamarin.AndroidX.Loader => 0x6bcd3296 => 156
	i32 1812481981, ; 197: Xamarin.Plugin.Calendar.dll => 0x6c0847bd => 220
	i32 1813058853, ; 198: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 215
	i32 1813201214, ; 199: Xamarin.Google.Android.Material => 0x6c13413e => 203
	i32 1815999139, ; 200: Xamarin.AndroidX.AutoFill => 0x6c3df2a3 => 127
	i32 1818569960, ; 201: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 162
	i32 1840964413, ; 202: FFImageLoading.Forms => 0x6dbae33d => 26
	i32 1866717392, ; 203: Xamarin.Android.Support.Interpolator.dll => 0x6f43d8d0 => 105
	i32 1867746548, ; 204: Xamarin.Essentials.dll => 0x6f538cf4 => 179
	i32 1872127555, ; 205: DevExpress.XamarinForms.Core.Android => 0x6f966643 => 19
	i32 1877418711, ; 206: Xamarin.Android.Support.v7.RecyclerView.dll => 0x6fe722d7 => 115
	i32 1878053835, ; 207: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 199
	i32 1881862856, ; 208: Xamarin.Forms.Maps.Android.dll => 0x702af2c8 => 193
	i32 1885316902, ; 209: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 125
	i32 1900610850, ; 210: System.Resources.ResourceManager.dll => 0x71490522 => 4
	i32 1908813208, ; 211: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 207
	i32 1916660109, ; 212: Xamarin.Android.Arch.Lifecycle.ViewModel.dll => 0x723de98d => 90
	i32 1919157823, ; 213: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 159
	i32 1933215285, ; 214: Xamarin.Firebase.Messaging.dll => 0x733a8635 => 189
	i32 1983156543, ; 215: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 214
	i32 1992830404, ; 216: DevExpress.Xamarin.Android.Charts.dll => 0x76c82dc4 => 12
	i32 2011961780, ; 217: System.Buffers.dll => 0x77ec19b4 => 71
	i32 2019465201, ; 218: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 154
	i32 2037417872, ; 219: Xamarin.Android.Support.ViewPager => 0x79708790 => 118
	i32 2044222327, ; 220: Xamarin.Android.Support.Loader => 0x79d85b77 => 106
	i32 2048185678, ; 221: Plugin.Media.dll => 0x7a14d54e => 54
	i32 2053795583, ; 222: Syncfusion.SfCalendar.XForms.Android.dll => 0x7a6a6eff => 69
	i32 2055257422, ; 223: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 150
	i32 2066383596, ; 224: FFImageLoading.Svg.Platform => 0x7b2a82ec => 30
	i32 2079903147, ; 225: System.Runtime.dll => 0x7bf8cdab => 79
	i32 2080493324, ; 226: NewBrokerApp.Android => 0x7c01cf0c => 1
	i32 2090596640, ; 227: System.Numerics.Vectors => 0x7c9bf920 => 77
	i32 2097448633, ; 228: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 146
	i32 2113902067, ; 229: Xamarin.Forms.PancakeView.dll => 0x7dff95f3 => 196
	i32 2123259399, ; 230: Syncfusion.SfCalendar.XForms => 0x7e8e5e07 => 70
	i32 2124230737, ; 231: Xamarin.Google.Android.DataTransport.TransportBackendCct.dll => 0x7e9d3051 => 201
	i32 2126786730, ; 232: Xamarin.Forms.Platform.Android => 0x7ec430aa => 197
	i32 2129483829, ; 233: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 206
	i32 2139458754, ; 234: Xamarin.Android.Support.DrawerLayout => 0x7f858cc2 => 103
	i32 2149007278, ; 235: DevExpress.Xamarin.Android.Editors => 0x80173fae => 14
	i32 2166116741, ; 236: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 98
	i32 2174878672, ; 237: Xamarin.Firebase.Annotations => 0x81a203d0 => 180
	i32 2193016926, ; 238: System.ObjectModel.dll => 0x82b6c85e => 232
	i32 2196165013, ; 239: Xamarin.Android.Support.VersionedParcelable => 0x82e6d195 => 117
	i32 2201107256, ; 240: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 219
	i32 2201231467, ; 241: System.Net.Http => 0x8334206b => 75
	i32 2217644978, ; 242: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 174
	i32 2234734091, ; 243: Xamarin.AndroidX.AutoFill.dll => 0x8533560b => 127
	i32 2244775296, ; 244: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 157
	i32 2256548716, ; 245: Xamarin.AndroidX.MultiDex => 0x8680336c => 159
	i32 2261435625, ; 246: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 148
	i32 2279755925, ; 247: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 166
	i32 2315684594, ; 248: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 120
	i32 2323008830, ; 249: DevExpress.XamarinForms.CollectionView.Android.dll => 0x8a764d3e => 17
	i32 2330457430, ; 250: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 97
	i32 2330986192, ; 251: Xamarin.Android.Support.SlidingPaneLayout.dll => 0x8af006d0 => 110
	i32 2340826669, ; 252: FFImageLoading.dll => 0x8b862e2d => 25
	i32 2343171156, ; 253: Syncfusion.Core.XForms => 0x8ba9f454 => 67
	i32 2349482313, ; 254: NewBrokerApp.resources => 0x8c0a4149 => 0
	i32 2353062107, ; 255: System.Net.Primitives => 0x8c40e0db => 238
	i32 2354730003, ; 256: Syncfusion.Licensing => 0x8c5a5413 => 68
	i32 2373288475, ; 257: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 104
	i32 2397082276, ; 258: Xamarin.Forms.PancakeView => 0x8ee092a4 => 196
	i32 2403452196, ; 259: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 142
	i32 2409053734, ; 260: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 163
	i32 2435904999, ; 261: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 227
	i32 2440966767, ; 262: Xamarin.Android.Support.Loader.dll => 0x917e326f => 106
	i32 2445024337, ; 263: Xamarin.Forms.GoogleMaps.Android.dll => 0x91bc1c51 => 191
	i32 2454642406, ; 264: System.Text.Encoding.dll => 0x924edee6 => 239
	i32 2465532216, ; 265: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 132
	i32 2471215200, ; 266: ImageCircle.Forms.Plugin => 0x934bc060 => 34
	i32 2471841756, ; 267: netstandard.dll => 0x93554fdc => 2
	i32 2475788418, ; 268: Java.Interop.dll => 0x93918882 => 35
	i32 2483661569, ; 269: Xamarin.Firebase.Measurement.Connector => 0x9409ab01 => 188
	i32 2483742551, ; 270: Xamarin.Firebase.Messaging => 0x940ae757 => 189
	i32 2486410006, ; 271: Xamarin.GooglePlayServices.CloudMessaging => 0x94339b16 => 208
	i32 2487632829, ; 272: Xamarin.Android.Support.DocumentFile => 0x944643bd => 102
	i32 2492892980, ; 273: Plugin.FilePicker.Abstractions.dll => 0x94968734 => 49
	i32 2501346920, ; 274: System.Data.DataSetExtensions => 0x95178668 => 223
	i32 2505896520, ; 275: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 153
	i32 2546258794, ; 276: Plugin.FilePicker.Abstractions => 0x97c4d36a => 49
	i32 2563143864, ; 277: AndHUD.dll => 0x98c678b8 => 11
	i32 2570120770, ; 278: System.Text.Encodings.Web => 0x9930ee42 => 80
	i32 2581819634, ; 279: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 175
	i32 2583753903, ; 280: DevExpress.XamarinForms.Editors.Android.dll => 0x9a00f4af => 21
	i32 2593964533, ; 281: Xamarin.Google.Dagger => 0x9a9cc1f5 => 204
	i32 2605712449, ; 282: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 219
	i32 2610962017, ; 283: DevExpress.Xamarin.Android.Editors.dll => 0x9ba01e61 => 14
	i32 2620871830, ; 284: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 137
	i32 2623491480, ; 285: Xamarin.Firebase.Installations.InterOp => 0x9c5f4d98 => 187
	i32 2624644809, ; 286: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 141
	i32 2633051222, ; 287: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 151
	i32 2684512982, ; 288: DevExpress.XamarinForms.Core => 0xa0026ad6 => 20
	i32 2693849962, ; 289: System.IO.dll => 0xa090e36a => 237
	i32 2696615099, ; 290: DevExpress.XamarinForms.Editors.dll => 0xa0bb14bb => 22
	i32 2698266930, ; 291: Xamarin.Android.Arch.Lifecycle.LiveData => 0xa0d44932 => 88
	i32 2701096212, ; 292: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 172
	i32 2715334215, ; 293: System.Threading.Tasks.dll => 0xa1d8b647 => 229
	i32 2732626843, ; 294: Xamarin.AndroidX.Activity => 0xa2e0939b => 119
	i32 2737747696, ; 295: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 122
	i32 2751899777, ; 296: Xamarin.Android.Support.Collections => 0xa406a881 => 94
	i32 2766581644, ; 297: Xamarin.Forms.Core => 0xa4e6af8c => 190
	i32 2768457651, ; 298: PropertyChanged => 0xa5034fb3 => 57
	i32 2770495804, ; 299: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 213
	i32 2772412848, ; 300: Xamarin.Google.Dagger.dll => 0xa53fa9b0 => 204
	i32 2778351058, ; 301: DevExpress.XamarinForms.CollectionView.Android => 0xa59a45d2 => 17
	i32 2778768386, ; 302: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 177
	i32 2779977773, ; 303: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 167
	i32 2788639665, ; 304: Xamarin.Android.Support.LocalBroadcastManager => 0xa63743b1 => 107
	i32 2788775637, ; 305: Xamarin.Android.Support.SwipeRefreshLayout.dll => 0xa63956d5 => 111
	i32 2795602088, ; 306: SkiaSharp.Views.Android.dll => 0xa6a180a8 => 62
	i32 2804607052, ; 307: Xamarin.Firebase.Components.dll => 0xa72ae84c => 182
	i32 2806986428, ; 308: Plugin.CurrentActivity.dll => 0xa74f36bc => 48
	i32 2810250172, ; 309: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 134
	i32 2819470561, ; 310: System.Xml.dll => 0xa80db4e1 => 82
	i32 2821294376, ; 311: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 167
	i32 2842369275, ; 312: FFImageLoading.Forms.Platform.dll => 0xa96b1cfb => 27
	i32 2843355708, ; 313: Lottie.Android.dll => 0xa97a2a3c => 36
	i32 2847418871, ; 314: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 206
	i32 2853208004, ; 315: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 177
	i32 2855708567, ; 316: Xamarin.AndroidX.Transition => 0xaa36a797 => 173
	i32 2861816565, ; 317: Rg.Plugins.Popup.dll => 0xaa93daf5 => 60
	i32 2868557005, ; 318: Syncfusion.Licensing.dll => 0xaafab4cd => 68
	i32 2870995654, ; 319: Xamarin.Firebase.Iid => 0xab1feac6 => 184
	i32 2873222696, ; 320: FFImageLoading => 0xab41e628 => 25
	i32 2874148507, ; 321: Syncfusion.Core.XForms.Android => 0xab50069b => 66
	i32 2876493027, ; 322: Xamarin.Android.Support.SwipeRefreshLayout => 0xab73cce3 => 111
	i32 2883826422, ; 323: Xamarin.Firebase.Installations => 0xabe3b2f6 => 186
	i32 2893257763, ; 324: Xamarin.Android.Arch.Core.Runtime.dll => 0xac739c23 => 85
	i32 2901442782, ; 325: System.Reflection => 0xacf080de => 233
	i32 2903344695, ; 326: System.ComponentModel.Composition => 0xad0d8637 => 225
	i32 2905242038, ; 327: mscorlib.dll => 0xad2a79b6 => 43
	i32 2912489636, ; 328: SkiaSharp.Views.Android => 0xad9910a4 => 62
	i32 2914202368, ; 329: Xamarin.Firebase.Iid.Interop => 0xadb33300 => 185
	i32 2916838712, ; 330: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 178
	i32 2919462931, ; 331: System.Numerics.Vectors.dll => 0xae037813 => 77
	i32 2921128767, ; 332: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 121
	i32 2921692953, ; 333: Xamarin.Android.Support.CustomView.dll => 0xae257f19 => 100
	i32 2922925221, ; 334: Xamarin.Android.Support.Vector.Drawable.dll => 0xae384ca5 => 116
	i32 2943219317, ; 335: Square.OkIO => 0xaf6df675 => 65
	i32 2972665880, ; 336: HttpExtension.dll => 0xb12f4818 => 33
	i32 2974793899, ; 337: SkiaSharp.Views.Forms.dll => 0xb14fc0ab => 63
	i32 2978675010, ; 338: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 140
	i32 2996846495, ; 339: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 152
	i32 3016983068, ; 340: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 170
	i32 3017076677, ; 341: Xamarin.GooglePlayServices.Maps => 0xb3d4efc5 => 209
	i32 3024354802, ; 342: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 147
	i32 3036068679, ; 343: Microcharts.Droid.dll => 0xb4f6bb47 => 39
	i32 3044182254, ; 344: FormsViewGroup => 0xb57288ee => 32
	i32 3048261857, ; 345: Splat.dll => 0xb5b0c8e1 => 64
	i32 3056250942, ; 346: Xamarin.Android.Support.AsyncLayoutInflater.dll => 0xb62ab03e => 93
	i32 3057625584, ; 347: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 160
	i32 3058099980, ; 348: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 211
	i32 3068715062, ; 349: Xamarin.Android.Arch.Lifecycle.Common => 0xb6e8e036 => 86
	i32 3071899978, ; 350: Xamarin.Firebase.Common.dll => 0xb719794a => 181
	i32 3075834255, ; 351: System.Threading.Tasks => 0xb755818f => 229
	i32 3092211740, ; 352: Xamarin.Android.Support.Media.Compat.dll => 0xb84f681c => 108
	i32 3104361006, ; 353: DLToolkit.Forms.Controls.FlowListView.dll => 0xb908ca2e => 23
	i32 3106737866, ; 354: Xamarin.Firebase.Datatransport.dll => 0xb92d0eca => 183
	i32 3111772706, ; 355: System.Runtime.Serialization => 0xb979e222 => 7
	i32 3124832203, ; 356: System.Threading.Tasks.Extensions => 0xba4127cb => 242
	i32 3126016514, ; 357: Plugin.Geolocator.dll => 0xba533a02 => 52
	i32 3155362983, ; 358: Xamarin.Google.Android.DataTransport.TransportApi => 0xbc1304a7 => 200
	i32 3177604865, ; 359: RatingBarControl.dll => 0xbd666701 => 58
	i32 3200023300, ; 360: DevExpress.XamarinForms.Editors.Android => 0xbebc7b04 => 21
	i32 3204380047, ; 361: System.Data.dll => 0xbefef58f => 221
	i32 3204912593, ; 362: Xamarin.Android.Support.AsyncLayoutInflater => 0xbf0715d1 => 93
	i32 3211777861, ; 363: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 139
	i32 3220365878, ; 364: System.Threading => 0xbff2e236 => 234
	i32 3230466174, ; 365: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 207
	i32 3233339011, ; 366: Xamarin.Android.Arch.Lifecycle.LiveData.Core.dll => 0xc0b8d683 => 87
	i32 3247949154, ; 367: Mono.Security => 0xc197c562 => 243
	i32 3249260365, ; 368: RestSharp.dll => 0xc1abc74d => 59
	i32 3258312781, ; 369: Xamarin.AndroidX.CardView => 0xc235e84d => 129
	i32 3263631797, ; 370: Lottie.Forms => 0xc28711b5 => 37
	i32 3265893370, ; 371: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 242
	i32 3267021929, ; 372: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 126
	i32 3280506390, ; 373: System.ComponentModel.Annotations.dll => 0xc3888e16 => 3
	i32 3291646556, ; 374: Splat => 0xc4328a5c => 64
	i32 3296380511, ; 375: Xamarin.Android.Support.Collections.dll => 0xc47ac65f => 94
	i32 3299076170, ; 376: Syncfusion.SfCalendar.XForms.dll => 0xc4a3e84a => 70
	i32 3299363146, ; 377: System.Text.Encoding => 0xc4a8494a => 239
	i32 3317135071, ; 378: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 138
	i32 3317144872, ; 379: System.Data => 0xc5b79d28 => 221
	i32 3321585405, ; 380: Xamarin.Android.Support.DocumentFile.dll => 0xc5fb5efd => 102
	i32 3331531814, ; 381: Xamarin.GooglePlayServices.Stats.dll => 0xc6932426 => 210
	i32 3340387945, ; 382: SkiaSharp => 0xc71a4669 => 61
	i32 3340431453, ; 383: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 125
	i32 3342024700, ; 384: Plugin.Connectivity.Abstractions.dll => 0xc7333ffc => 46
	i32 3345895724, ; 385: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 165
	i32 3346324047, ; 386: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 161
	i32 3352662376, ; 387: Xamarin.Android.Support.CoordinaterLayout => 0xc7d59168 => 96
	i32 3353484488, ; 388: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 146
	i32 3357663996, ; 389: Xamarin.Android.Support.CursorAdapter => 0xc821e2fc => 99
	i32 3358260929, ; 390: System.Text.Json => 0xc82afec1 => 81
	i32 3362522851, ; 391: Xamarin.AndroidX.Core => 0xc86c06e3 => 136
	i32 3366046733, ; 392: Plugin.Connectivity.dll => 0xc8a1cc0d => 47
	i32 3366347497, ; 393: Java.Interop => 0xc8a662e9 => 35
	i32 3369564201, ; 394: Acr.Support.Android.dll => 0xc8d77829 => 8
	i32 3374999561, ; 395: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 166
	i32 3395150330, ; 396: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 78
	i32 3401559547, ; 397: Plugin.FirebasePushNotification.dll => 0xcabfadfb => 51
	i32 3404865022, ; 398: System.ServiceModel.Internals => 0xcaf21dfe => 228
	i32 3429136800, ; 399: System.Xml => 0xcc6479a0 => 82
	i32 3430777524, ; 400: netstandard => 0xcc7d82b4 => 2
	i32 3439690031, ; 401: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 92
	i32 3441283291, ; 402: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 141
	i32 3442543374, ; 403: AndHUD => 0xcd310b0e => 11
	i32 3446806427, ; 404: RatingBarControl => 0xcd72179b => 58
	i32 3448896322, ; 405: Polly => 0xcd91fb42 => 56
	i32 3455791806, ; 406: Microcharts => 0xcdfb32be => 38
	i32 3459516321, ; 407: Xamarin.Forms.GoogleMaps => 0xce3407a1 => 192
	i32 3471764580, ; 408: DevExpress.Xamarin.Android.Charts => 0xceeeec64 => 12
	i32 3476120550, ; 409: Mono.Android => 0xcf3163e6 => 42
	i32 3483112796, ; 410: ImageCircle.Forms.Plugin.dll => 0xcf9c155c => 34
	i32 3485117614, ; 411: System.Text.Json.dll => 0xcfbaacae => 81
	i32 3486566296, ; 412: System.Transactions => 0xcfd0c798 => 222
	i32 3493954962, ; 413: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 131
	i32 3501239056, ; 414: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 126
	i32 3509114376, ; 415: System.Xml.Linq => 0xd128d608 => 83
	i32 3536029504, ; 416: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 197
	i32 3547625832, ; 417: Xamarin.Android.Support.SlidingPaneLayout => 0xd3747968 => 110
	i32 3567349600, ; 418: System.ComponentModel.Composition.dll => 0xd4a16f60 => 225
	i32 3588335826, ; 419: DevExpress.Xamarin.Android.CollectionView => 0xd5e1a8d2 => 13
	i32 3608519521, ; 420: System.Linq.dll => 0xd715a361 => 236
	i32 3618140916, ; 421: Xamarin.AndroidX.Preference => 0xd7a872f4 => 163
	i32 3620579205, ; 422: Acr.UserDialogs.Interface => 0xd7cda785 => 10
	i32 3625525219, ; 423: DropdownMenu.dll => 0xd8191fe3 => 24
	i32 3627220390, ; 424: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 164
	i32 3632359727, ; 425: Xamarin.Forms.Platform => 0xd881692f => 198
	i32 3633644679, ; 426: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 121
	i32 3639449509, ; 427: Lottie.Android => 0xd8ed97a5 => 36
	i32 3641597786, ; 428: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 150
	i32 3645089577, ; 429: System.ComponentModel.DataAnnotations => 0xd943a729 => 227
	i32 3664423555, ; 430: Xamarin.Android.Support.ViewPager.dll => 0xda6aaa83 => 118
	i32 3668042751, ; 431: Microcharts.dll => 0xdaa1e3ff => 38
	i32 3672681054, ; 432: Mono.Android.dll => 0xdae8aa5e => 42
	i32 3676310014, ; 433: System.Web.Services.dll => 0xdb2009fe => 226
	i32 3678221644, ; 434: Xamarin.Android.Support.v7.AppCompat => 0xdb3d354c => 114
	i32 3681174138, ; 435: Xamarin.Android.Arch.Lifecycle.Common.dll => 0xdb6a427a => 86
	i32 3682565725, ; 436: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 128
	i32 3684561358, ; 437: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 131
	i32 3689375977, ; 438: System.Drawing.Common => 0xdbe768e9 => 6
	i32 3690415161, ; 439: NewBrokerApp => 0xdbf74439 => 44
	i32 3706696989, ; 440: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 135
	i32 3711641445, ; 441: DropdownMenu => 0xdd3b2765 => 24
	i32 3714038699, ; 442: Xamarin.Android.Support.LocalBroadcastManager.dll => 0xdd5fbbab => 107
	i32 3718463572, ; 443: Xamarin.Android.Support.Animated.Vector.Drawable.dll => 0xdda34054 => 91
	i32 3718780102, ; 444: Xamarin.AndroidX.Annotation => 0xdda814c6 => 120
	i32 3724971120, ; 445: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 160
	i32 3755886552, ; 446: DevExpress.XamarinForms.Charts.Android.dll => 0xdfde47d8 => 15
	i32 3758932259, ; 447: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 148
	i32 3776062606, ; 448: Xamarin.Android.Support.DrawerLayout.dll => 0xe112248e => 103
	i32 3776811843, ; 449: Plugin.InputKit.dll => 0xe11d9343 => 53
	i32 3786282454, ; 450: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 130
	i32 3816437471, ; 451: RestSharp => 0xe37a36df => 59
	i32 3822602673, ; 452: Xamarin.AndroidX.Media => 0xe3d849b1 => 158
	i32 3829621856, ; 453: System.Numerics.dll => 0xe4436460 => 76
	i32 3832731800, ; 454: Xamarin.Android.Support.CoordinaterLayout.dll => 0xe472d898 => 96
	i32 3862817207, ; 455: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0xe63de9b7 => 89
	i32 3874897629, ; 456: Xamarin.Android.Arch.Lifecycle.Runtime => 0xe6f63edd => 89
	i32 3883175360, ; 457: Xamarin.Android.Support.v7.AppCompat.dll => 0xe7748dc0 => 114
	i32 3885922214, ; 458: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 173
	i32 3888767677, ; 459: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 165
	i32 3896760992, ; 460: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 136
	i32 3903721208, ; 461: Microcharts.Forms => 0xe8ae0ef8 => 40
	i32 3912468689, ; 462: FFImageLoading.Svg.Platform.dll => 0xe93388d1 => 30
	i32 3914259587, ; 463: Plugin.Connectivity => 0xe94edc83 => 47
	i32 3918985652, ; 464: DevExpress.XamarinForms.Charts.dll => 0xe996f9b4 => 16
	i32 3920810846, ; 465: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 224
	i32 3921031405, ; 466: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 176
	i32 3931092270, ; 467: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 162
	i32 3934056515, ; 468: Xamarin.JavaX.Inject.dll => 0xea7cf043 => 212
	i32 3945713374, ; 469: System.Data.DataSetExtensions.dll => 0xeb2ecede => 223
	i32 3955647286, ; 470: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 123
	i32 3959773229, ; 471: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 152
	i32 3970018735, ; 472: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 211
	i32 4025784931, ; 473: System.Memory => 0xeff49a63 => 244
	i32 4063435586, ; 474: Xamarin.Android.Support.CustomView => 0xf2331b42 => 100
	i32 4073602200, ; 475: System.Threading.dll => 0xf2ce3c98 => 234
	i32 4101593132, ; 476: Xamarin.AndroidX.Emoji2 => 0xf479582c => 142
	i32 4105002889, ; 477: Mono.Security.dll => 0xf4ad5f89 => 243
	i32 4151237749, ; 478: System.Core => 0xf76edc75 => 72
	i32 4182413190, ; 479: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 155
	i32 4184000013, ; 480: PropertyChanged.dll => 0xf962c60d => 57
	i32 4184283386, ; 481: FFImageLoading.Platform.dll => 0xf96718fa => 28
	i32 4216993138, ; 482: Xamarin.Android.Support.Transition.dll => 0xfb5a3572 => 112
	i32 4256097574, ; 483: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 135
	i32 4260525087, ; 484: System.Buffers => 0xfdf2741f => 71
	i32 4267535345, ; 485: DevExpress.XamarinForms.CollectionView.dll => 0xfe5d6bf1 => 18
	i32 4269159614, ; 486: Xamarin.Firebase.Datatransport => 0xfe7634be => 183
	i32 4278134329, ; 487: Xamarin.GooglePlayServices.Maps.dll => 0xfeff2639 => 209
	i32 4284549794, ; 488: Xamarin.Firebase.Components => 0xff610aa2 => 182
	i32 4292120959 ; 489: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 155
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [490 x i32] [
	i32 153, i32 205, i32 45, i32 55, i32 190, i32 117, i32 9, i32 184, ; 0..7
	i32 169, i32 180, i32 169, i32 216, i32 37, i32 3, i32 84, i32 130, ; 8..15
	i32 95, i32 171, i32 85, i32 128, i32 193, i32 113, i32 230, i32 147, ; 16..23
	i32 241, i32 226, i32 133, i32 151, i32 145, i32 112, i32 119, i32 194, ; 24..31
	i32 76, i32 149, i32 1, i32 44, i32 244, i32 91, i32 97, i32 220, ; 32..39
	i32 132, i32 179, i32 231, i32 144, i32 43, i32 73, i32 145, i32 202, ; 40..47
	i32 157, i32 202, i32 232, i32 200, i32 95, i32 28, i32 109, i32 61, ; 48..55
	i32 222, i32 216, i32 101, i32 210, i32 235, i32 41, i32 15, i32 115, ; 56..63
	i32 29, i32 224, i32 138, i32 143, i32 80, i32 176, i32 124, i32 46, ; 64..71
	i32 83, i32 218, i32 9, i32 92, i32 31, i32 213, i32 67, i32 217, ; 72..79
	i32 74, i32 53, i32 23, i32 105, i32 6, i32 0, i32 164, i32 29, ; 80..87
	i32 186, i32 241, i32 187, i32 113, i32 39, i32 60, i32 109, i32 205, ; 88..95
	i32 18, i32 45, i32 217, i32 48, i32 108, i32 65, i32 149, i32 32, ; 96..103
	i32 88, i32 231, i32 201, i32 168, i32 123, i32 208, i32 198, i32 154, ; 104..111
	i32 215, i32 90, i32 73, i32 54, i32 8, i32 56, i32 55, i32 188, ; 112..119
	i32 174, i32 161, i32 50, i32 124, i32 33, i32 170, i32 175, i32 50, ; 120..127
	i32 218, i32 52, i32 195, i32 99, i32 140, i32 87, i32 51, i32 10, ; 128..135
	i32 236, i32 181, i32 192, i32 101, i32 237, i32 228, i32 191, i32 168, ; 136..143
	i32 4, i32 212, i32 158, i32 134, i32 78, i32 104, i32 20, i32 13, ; 144..151
	i32 235, i32 199, i32 74, i32 122, i32 66, i32 195, i32 194, i32 27, ; 152..159
	i32 185, i32 240, i32 5, i32 98, i32 19, i32 139, i32 40, i32 22, ; 160..167
	i32 84, i32 7, i32 69, i32 156, i32 178, i32 143, i32 31, i32 137, ; 168..175
	i32 75, i32 240, i32 79, i32 172, i32 203, i32 16, i32 116, i32 133, ; 176..183
	i32 238, i32 214, i32 230, i32 63, i32 233, i32 129, i32 5, i32 171, ; 184..191
	i32 72, i32 144, i32 26, i32 41, i32 156, i32 220, i32 215, i32 203, ; 192..199
	i32 127, i32 162, i32 26, i32 105, i32 179, i32 19, i32 115, i32 199, ; 200..207
	i32 193, i32 125, i32 4, i32 207, i32 90, i32 159, i32 189, i32 214, ; 208..215
	i32 12, i32 71, i32 154, i32 118, i32 106, i32 54, i32 69, i32 150, ; 216..223
	i32 30, i32 79, i32 1, i32 77, i32 146, i32 196, i32 70, i32 201, ; 224..231
	i32 197, i32 206, i32 103, i32 14, i32 98, i32 180, i32 232, i32 117, ; 232..239
	i32 219, i32 75, i32 174, i32 127, i32 157, i32 159, i32 148, i32 166, ; 240..247
	i32 120, i32 17, i32 97, i32 110, i32 25, i32 67, i32 0, i32 238, ; 248..255
	i32 68, i32 104, i32 196, i32 142, i32 163, i32 227, i32 106, i32 191, ; 256..263
	i32 239, i32 132, i32 34, i32 2, i32 35, i32 188, i32 189, i32 208, ; 264..271
	i32 102, i32 49, i32 223, i32 153, i32 49, i32 11, i32 80, i32 175, ; 272..279
	i32 21, i32 204, i32 219, i32 14, i32 137, i32 187, i32 141, i32 151, ; 280..287
	i32 20, i32 237, i32 22, i32 88, i32 172, i32 229, i32 119, i32 122, ; 288..295
	i32 94, i32 190, i32 57, i32 213, i32 204, i32 17, i32 177, i32 167, ; 296..303
	i32 107, i32 111, i32 62, i32 182, i32 48, i32 134, i32 82, i32 167, ; 304..311
	i32 27, i32 36, i32 206, i32 177, i32 173, i32 60, i32 68, i32 184, ; 312..319
	i32 25, i32 66, i32 111, i32 186, i32 85, i32 233, i32 225, i32 43, ; 320..327
	i32 62, i32 185, i32 178, i32 77, i32 121, i32 100, i32 116, i32 65, ; 328..335
	i32 33, i32 63, i32 140, i32 152, i32 170, i32 209, i32 147, i32 39, ; 336..343
	i32 32, i32 64, i32 93, i32 160, i32 211, i32 86, i32 181, i32 229, ; 344..351
	i32 108, i32 23, i32 183, i32 7, i32 242, i32 52, i32 200, i32 58, ; 352..359
	i32 21, i32 221, i32 93, i32 139, i32 234, i32 207, i32 87, i32 243, ; 360..367
	i32 59, i32 129, i32 37, i32 242, i32 126, i32 3, i32 64, i32 94, ; 368..375
	i32 70, i32 239, i32 138, i32 221, i32 102, i32 210, i32 61, i32 125, ; 376..383
	i32 46, i32 165, i32 161, i32 96, i32 146, i32 99, i32 81, i32 136, ; 384..391
	i32 47, i32 35, i32 8, i32 166, i32 78, i32 51, i32 228, i32 82, ; 392..399
	i32 2, i32 92, i32 141, i32 11, i32 58, i32 56, i32 38, i32 192, ; 400..407
	i32 12, i32 42, i32 34, i32 81, i32 222, i32 131, i32 126, i32 83, ; 408..415
	i32 197, i32 110, i32 225, i32 13, i32 236, i32 163, i32 10, i32 24, ; 416..423
	i32 164, i32 198, i32 121, i32 36, i32 150, i32 227, i32 118, i32 38, ; 424..431
	i32 42, i32 226, i32 114, i32 86, i32 128, i32 131, i32 6, i32 44, ; 432..439
	i32 135, i32 24, i32 107, i32 91, i32 120, i32 160, i32 15, i32 148, ; 440..447
	i32 103, i32 53, i32 130, i32 59, i32 158, i32 76, i32 96, i32 89, ; 448..455
	i32 89, i32 114, i32 173, i32 165, i32 136, i32 40, i32 30, i32 47, ; 456..463
	i32 16, i32 224, i32 176, i32 162, i32 212, i32 223, i32 123, i32 152, ; 464..471
	i32 211, i32 244, i32 100, i32 234, i32 142, i32 243, i32 72, i32 155, ; 472..479
	i32 57, i32 28, i32 112, i32 135, i32 71, i32 18, i32 183, i32 209, ; 480..487
	i32 182, i32 155 ; 488..489
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
