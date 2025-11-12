; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [334 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [662 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 247
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 281
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 39109920, ; 6: Newtonsoft.Json.dll => 0x254c520 => 193
	i32 39485524, ; 7: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42639949, ; 8: System.Threading.Thread => 0x28aa24d => 145
	i32 66541672, ; 9: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 10: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 322
	i32 68219467, ; 11: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 12: Microsoft.Maui.Graphics.dll => 0x44bb714 => 191
	i32 82292897, ; 13: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 101534019, ; 14: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 265
	i32 117431740, ; 15: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 16: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 265
	i32 122350210, ; 17: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 18: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 285
	i32 142721839, ; 19: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 20: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 21: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 22: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 221
	i32 172961045, ; 23: Syncfusion.Maui.Core.dll => 0xa4f2d15 => 196
	i32 176265551, ; 24: System.ServiceProcess => 0xa81994f => 132
	i32 182336117, ; 25: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 267
	i32 184328833, ; 26: System.ValueTuple.dll => 0xafca281 => 151
	i32 195452805, ; 27: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 319
	i32 199333315, ; 28: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 320
	i32 205061960, ; 29: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 30: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 219
	i32 220171995, ; 31: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 32: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 241
	i32 230752869, ; 33: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 34: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 35: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 36: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 261689757, ; 37: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 224
	i32 276479776, ; 38: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 278686392, ; 39: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 243
	i32 280482487, ; 40: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 240
	i32 280992041, ; 41: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 291
	i32 291076382, ; 42: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 298918909, ; 43: System.Net.Ping.dll => 0x11d123fd => 69
	i32 317674968, ; 44: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 319
	i32 318968648, ; 45: Xamarin.AndroidX.Activity.dll => 0x13031348 => 210
	i32 321597661, ; 46: System.Numerics => 0x132b30dd => 83
	i32 336156722, ; 47: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 304
	i32 342366114, ; 48: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 242
	i32 356389973, ; 49: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 303
	i32 360082299, ; 50: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 51: System.IO.Pipes => 0x15ebe147 => 55
	i32 374376850, ; 52: Syncfusion.Maui.Popup.dll => 0x16508992 => 203
	i32 374794515, ; 53: Syncfusion.Maui.Data.dll => 0x1656e913 => 197
	i32 374914964, ; 54: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 55: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 376991480, ; 56: en-US/Syncfusion.Maui.Buttons.resources.dll => 0x16786ef8 => 323
	i32 379916513, ; 57: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 58: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 59: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 60: _Microsoft.Android.Resource.Designer => 0x17969339 => 330
	i32 403441872, ; 61: WindowsBase => 0x180c08d0 => 165
	i32 435591531, ; 62: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 315
	i32 441335492, ; 63: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 225
	i32 442565967, ; 64: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 65: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 238
	i32 451504562, ; 66: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 67: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 456681651, ; 68: Syncfusion.Maui.GridCommon.dll => 0x1b3868b3 => 200
	i32 459347974, ; 69: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 70: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 71: System.dll => 0x1bff388e => 164
	i32 476646585, ; 72: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 240
	i32 486930444, ; 73: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 253
	i32 488065789, ; 74: en-US/Syncfusion.Maui.DataGrid.resources.dll => 0x1d174afd => 324
	i32 498788369, ; 75: System.ObjectModel => 0x1dbae811 => 84
	i32 500358224, ; 76: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 302
	i32 503918385, ; 77: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 296
	i32 513247710, ; 78: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 185
	i32 526420162, ; 79: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 80: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 285
	i32 530272170, ; 81: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 539058512, ; 82: Microsoft.Extensions.Logging => 0x20216150 => 181
	i32 540030774, ; 83: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 84: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 85: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 86: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 87: Jsr305Binding => 0x213954e7 => 278
	i32 569601784, ; 88: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 276
	i32 577335427, ; 89: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 592146354, ; 90: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 310
	i32 597488923, ; 91: CommunityToolkit.Maui => 0x239cf51b => 174
	i32 601371474, ; 92: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 93: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 94: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 95: Xamarin.AndroidX.CustomView => 0x2568904f => 230
	i32 627931235, ; 96: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 308
	i32 639843206, ; 97: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 236
	i32 643868501, ; 98: System.Net => 0x2660a755 => 81
	i32 662205335, ; 99: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 100: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 272
	i32 666292255, ; 101: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 217
	i32 672442732, ; 102: System.Collections.Concurrent => 0x2814a96c => 8
	i32 676419328, ; 103: en-US\Syncfusion.Maui.Buttons.resources => 0x28515700 => 323
	i32 683518922, ; 104: System.Net.Security => 0x28bdabca => 73
	i32 688181140, ; 105: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 290
	i32 690569205, ; 106: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 107: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 287
	i32 693804605, ; 108: System.Windows => 0x295a9e3d => 154
	i32 695450347, ; 109: Syncfusion.Maui.Popup => 0x2973baeb => 203
	i32 699345723, ; 110: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 111: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 282
	i32 700358131, ; 112: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 706645707, ; 113: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 305
	i32 709557578, ; 114: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 293
	i32 720511267, ; 115: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 286
	i32 722857257, ; 116: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 735137430, ; 117: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 118: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 119: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 207
	i32 759454413, ; 120: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 121: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 122: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 123: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 314
	i32 789151979, ; 124: Microsoft.Extensions.Options => 0x2f0980eb => 184
	i32 790371945, ; 125: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 231
	i32 804715423, ; 126: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 127: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 245
	i32 823281589, ; 128: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 129: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 130: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 131: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 132: Xamarin.AndroidX.Print => 0x3246f6cd => 258
	i32 873119928, ; 133: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 134: System.Globalization.dll => 0x34505120 => 42
	i32 878833237, ; 135: en-US\Syncfusion.Maui.DataGrid.resources => 0x3461ee55 => 324
	i32 878954865, ; 136: System.Net.Http.Json => 0x3463c971 => 63
	i32 904024072, ; 137: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 138: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 926902833, ; 139: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 317
	i32 928116545, ; 140: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 281
	i32 952186615, ; 141: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 955402788, ; 142: Newtonsoft.Json => 0x38f24a24 => 193
	i32 956575887, ; 143: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 286
	i32 966729478, ; 144: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 279
	i32 967690846, ; 145: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 242
	i32 975236339, ; 146: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 147: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 148: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 149: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 992768348, ; 150: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 151: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 1001831731, ; 152: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 153: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 262
	i32 1019214401, ; 154: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 155: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 180
	i32 1029334545, ; 156: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 292
	i32 1031528504, ; 157: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 280
	i32 1035644815, ; 158: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 215
	i32 1036536393, ; 159: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1044663988, ; 160: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1052210849, ; 161: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 249
	i32 1067306892, ; 162: GoogleGson => 0x3f9dcf8c => 176
	i32 1082857460, ; 163: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 164: Xamarin.Kotlin.StdLib => 0x409e66d8 => 283
	i32 1098259244, ; 165: System => 0x41761b2c => 164
	i32 1118262833, ; 166: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 305
	i32 1121599056, ; 167: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 248
	i32 1126950560, ; 168: Syncfusion.Maui.PullToRefresh.dll => 0x432be6a0 => 204
	i32 1127624469, ; 169: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 183
	i32 1149092582, ; 170: Xamarin.AndroidX.Window => 0x447dc2e6 => 275
	i32 1168523401, ; 171: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 311
	i32 1170634674, ; 172: System.Web.dll => 0x45c677b2 => 153
	i32 1175144683, ; 173: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 271
	i32 1178241025, ; 174: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 256
	i32 1203215381, ; 175: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 309
	i32 1204270330, ; 176: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 217
	i32 1208641965, ; 177: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1219128291, ; 178: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1234928153, ; 179: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 307
	i32 1243150071, ; 180: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 276
	i32 1253011324, ; 181: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 182: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 291
	i32 1264511973, ; 183: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 266
	i32 1267360935, ; 184: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 270
	i32 1273260888, ; 185: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 222
	i32 1275534314, ; 186: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 287
	i32 1278448581, ; 187: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 214
	i32 1293217323, ; 188: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 233
	i32 1309188875, ; 189: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1322716291, ; 190: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 275
	i32 1324164729, ; 191: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 192: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1364015309, ; 193: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 194: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 321
	i32 1376866003, ; 195: Xamarin.AndroidX.SavedState => 0x52114ed3 => 262
	i32 1379779777, ; 196: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 197: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 198: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 226
	i32 1408764838, ; 199: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 200: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 201: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 202: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 289
	i32 1434145427, ; 203: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 204: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 279
	i32 1439761251, ; 205: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 206: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 207: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1457743152, ; 208: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 209: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1461004990, ; 210: es\Microsoft.Maui.Controls.resources => 0x57152abe => 295
	i32 1461234159, ; 211: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 212: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 213: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 214: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 216
	i32 1470490898, ; 215: Microsoft.Extensions.Primitives => 0x57a5e912 => 185
	i32 1479771757, ; 216: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 217: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 218: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 219: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 263
	i32 1493001747, ; 220: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 299
	i32 1508333500, ; 221: PMEGPCUSTOMERBank => 0x59e757bc => 0
	i32 1514721132, ; 222: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 294
	i32 1536373174, ; 223: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1537889881, ; 224: Syncfusion.Maui.Buttons.dll => 0x5baa5659 => 195
	i32 1543031311, ; 225: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 226: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 227: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1551623176, ; 228: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 314
	i32 1565862583, ; 229: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 230: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 231: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 232: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 233: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 232
	i32 1589115732, ; 234: Syncfusion.Maui.Data => 0x5eb7fb54 => 197
	i32 1592978981, ; 235: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1596911864, ; 236: Syncfusion.Maui.Buttons => 0x5f2ef0f8 => 195
	i32 1597949149, ; 237: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 280
	i32 1601112923, ; 238: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1603525486, ; 239: Microsoft.Maui.Controls.HotReload.Forms.dll => 0x5f93db6e => 326
	i32 1604827217, ; 240: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 241: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 242: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 252
	i32 1622358360, ; 243: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 244: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 274
	i32 1634654947, ; 245: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 175
	i32 1635184631, ; 246: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 236
	i32 1636350590, ; 247: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 229
	i32 1639515021, ; 248: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 249: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 250: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1653151792, ; 251: Syncfusion.Maui.Inputs.dll => 0x62891830 => 201
	i32 1657153582, ; 252: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 253: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 268
	i32 1658251792, ; 254: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 277
	i32 1667453763, ; 255: Mopups.dll => 0x63635343 => 192
	i32 1670060433, ; 256: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 224
	i32 1675553242, ; 257: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 258: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 259: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 260: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 261: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 262: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 263: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 284
	i32 1701541528, ; 264: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 265: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 245
	i32 1726116996, ; 266: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 267: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 268: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 220
	i32 1736233607, ; 269: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 312
	i32 1743415430, ; 270: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 290
	i32 1744735666, ; 271: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746316138, ; 272: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 273: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 274: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 275: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 276: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 277: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 267
	i32 1770582343, ; 278: Microsoft.Extensions.Logging.dll => 0x6988f147 => 181
	i32 1776026572, ; 279: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 280: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1779859068, ; 281: Syncfusion.Maui.DataGrid.dll => 0x6a167e7c => 198
	i32 1780572499, ; 282: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782862114, ; 283: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 306
	i32 1788241197, ; 284: Xamarin.AndroidX.Fragment => 0x6a96652d => 238
	i32 1793755602, ; 285: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 298
	i32 1808609942, ; 286: Xamarin.AndroidX.Loader => 0x6bcd3296 => 252
	i32 1813058853, ; 287: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 283
	i32 1813201214, ; 288: Xamarin.Google.Android.Material => 0x6c13413e => 277
	i32 1818569960, ; 289: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 257
	i32 1818787751, ; 290: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 291: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 292: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1827303595, ; 293: Microsoft.VisualStudio.DesignTools.TapContract => 0x6cea70ab => 328
	i32 1828688058, ; 294: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 182
	i32 1842015223, ; 295: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 318
	i32 1847515442, ; 296: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 207
	i32 1853025655, ; 297: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 315
	i32 1858542181, ; 298: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 299: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1875935024, ; 300: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 297
	i32 1879696579, ; 301: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 302: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 218
	i32 1885918049, ; 303: Microsoft.VisualStudio.DesignTools.TapContract.dll => 0x7068d361 => 328
	i32 1888955245, ; 304: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 305: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1898237753, ; 306: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 307: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 308: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1939592360, ; 309: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1956758971, ; 310: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 311: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 264
	i32 1968388702, ; 312: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 177
	i32 1968499395, ; 313: AsyncAwaitBestPractices => 0x7554eac3 => 173
	i32 1983156543, ; 314: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 284
	i32 1985761444, ; 315: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 209
	i32 2003115576, ; 316: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 294
	i32 2011961780, ; 317: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 318: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 249
	i32 2025202353, ; 319: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 289
	i32 2031763787, ; 320: Xamarin.Android.Glide => 0x791a414b => 206
	i32 2045470958, ; 321: System.Private.Xml => 0x79eb68ee => 88
	i32 2055257422, ; 322: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 244
	i32 2060060697, ; 323: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 324: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 293
	i32 2070888862, ; 325: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2079903147, ; 326: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 327: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2117912485, ; 328: Microsoft.VisualStudio.DesignTools.XamlTapContract.dll => 0x7e3cc7a5 => 329
	i32 2127167465, ; 329: System.Console => 0x7ec9ffe9 => 20
	i32 2134827680, ; 330: Syncfusion.Maui.Sliders.dll => 0x7f3ee2a0 => 205
	i32 2142473426, ; 331: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 332: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 333: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 334: Microsoft.Maui => 0x80bd55ad => 189
	i32 2169148018, ; 335: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 301
	i32 2181898931, ; 336: Microsoft.Extensions.Options.dll => 0x820d22b3 => 184
	i32 2192057212, ; 337: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 182
	i32 2193016926, ; 338: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201107256, ; 339: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 288
	i32 2201231467, ; 340: System.Net.Http => 0x8334206b => 64
	i32 2207618523, ; 341: it\Microsoft.Maui.Controls.resources => 0x839595db => 303
	i32 2217644978, ; 342: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 271
	i32 2222056684, ; 343: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2244775296, ; 344: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 253
	i32 2252106437, ; 345: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 346: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 347: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 348: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 178
	i32 2267999099, ; 349: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 208
	i32 2270573516, ; 350: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 297
	i32 2279755925, ; 351: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 260
	i32 2293034957, ; 352: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 353: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 354: System.Net.Mail => 0x88ffe49e => 66
	i32 2303942373, ; 355: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 307
	i32 2305521784, ; 356: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2315684594, ; 357: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 212
	i32 2320631194, ; 358: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 359: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 360: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 361: System.Net.Primitives => 0x8c40e0db => 70
	i32 2354730003, ; 362: Syncfusion.Licensing => 0x8c5a5413 => 194
	i32 2368005991, ; 363: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2371007202, ; 364: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 177
	i32 2378619854, ; 365: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 366: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 367: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 302
	i32 2401565422, ; 368: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 369: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 235
	i32 2409983638, ; 370: Microsoft.VisualStudio.DesignTools.MobileTapContracts.dll => 0x8fa56e96 => 327
	i32 2421380589, ; 371: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 372: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 222
	i32 2426750280, ; 373: en-US\Syncfusion.Maui.Inputs.resources => 0x90a54548 => 325
	i32 2427813419, ; 374: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 299
	i32 2435356389, ; 375: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 376: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 377: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 378: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 379: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465532216, ; 380: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 225
	i32 2471841756, ; 381: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 382: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 383: Microsoft.Maui.Controls => 0x93dba8a1 => 187
	i32 2483903535, ; 384: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 385: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 386: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 387: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2505896520, ; 388: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 247
	i32 2522472828, ; 389: Xamarin.Android.Glide.dll => 0x9659e17c => 206
	i32 2538310050, ; 390: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 391: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 300
	i32 2562349572, ; 392: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 393: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2581783588, ; 394: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 248
	i32 2581819634, ; 395: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 270
	i32 2585220780, ; 396: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 397: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 398: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2593496499, ; 399: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 309
	i32 2605712449, ; 400: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 288
	i32 2615233544, ; 401: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 239
	i32 2616218305, ; 402: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 183
	i32 2617129537, ; 403: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 404: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 405: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 229
	i32 2624644809, ; 406: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 234
	i32 2626831493, ; 407: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 304
	i32 2627185994, ; 408: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 409: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 410: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 243
	i32 2663391936, ; 411: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 208
	i32 2663698177, ; 412: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 413: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 414: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 415: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 416: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 417: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 418: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 268
	i32 2707746672, ; 419: Syncfusion.Maui.PullToRefresh => 0xa164ef70 => 204
	i32 2715334215, ; 420: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 421: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 422: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 423: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 424: Xamarin.AndroidX.Activity => 0xa2e0939b => 210
	i32 2735172069, ; 425: System.Threading.Channels => 0xa30769e5 => 139
	i32 2737747696, ; 426: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 216
	i32 2740948882, ; 427: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2743368605, ; 428: Syncfusion.Maui.DataSource => 0xa3847b9d => 199
	i32 2748088231, ; 429: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 430: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 310
	i32 2758225723, ; 431: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 188
	i32 2764765095, ; 432: Microsoft.Maui.dll => 0xa4caf7a7 => 189
	i32 2765824710, ; 433: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 434: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 282
	i32 2778768386, ; 435: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 273
	i32 2779977773, ; 436: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 261
	i32 2785988530, ; 437: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 316
	i32 2788224221, ; 438: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 239
	i32 2801831435, ; 439: Microsoft.Maui.Graphics => 0xa7008e0b => 191
	i32 2803228030, ; 440: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2806116107, ; 441: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 295
	i32 2810250172, ; 442: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 226
	i32 2819470561, ; 443: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 444: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 445: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 261
	i32 2824502124, ; 446: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2831556043, ; 447: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 308
	i32 2838993487, ; 448: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 250
	i32 2842426040, ; 449: Syncfusion.Maui.Sliders => 0xa96bfab8 => 205
	i32 2849599387, ; 450: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 451: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 273
	i32 2855708567, ; 452: Xamarin.AndroidX.Transition => 0xaa36a797 => 269
	i32 2861098320, ; 453: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 454: Microsoft.Maui.Essentials => 0xaa8a4878 => 190
	i32 2868488919, ; 455: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 175
	i32 2868557005, ; 456: Syncfusion.Licensing.dll => 0xaafab4cd => 194
	i32 2870099610, ; 457: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 211
	i32 2875164099, ; 458: Jsr305Binding.dll => 0xab5f85c3 => 278
	i32 2875220617, ; 459: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 460: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 237
	i32 2887636118, ; 461: System.Net.dll => 0xac1dd496 => 81
	i32 2899753641, ; 462: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 463: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 464: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 465: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 466: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2915140907, ; 467: Syncfusion.Maui.DataGrid => 0xadc1852b => 198
	i32 2916838712, ; 468: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 274
	i32 2919462931, ; 469: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 470: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 213
	i32 2936416060, ; 471: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 472: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 473: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 474: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 475: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2972252294, ; 476: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 477: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 233
	i32 2987532451, ; 478: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 264
	i32 2996846495, ; 479: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 246
	i32 3016983068, ; 480: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 266
	i32 3023353419, ; 481: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 482: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 241
	i32 3038032645, ; 483: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 330
	i32 3056245963, ; 484: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 263
	i32 3057625584, ; 485: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 254
	i32 3059408633, ; 486: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 487: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 488: System.Threading.Tasks => 0xb755818f => 144
	i32 3077302341, ; 489: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 301
	i32 3090735792, ; 490: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 491: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 492: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 493: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 494: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 495: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 496: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3140633799, ; 497: Syncfusion.Maui.ListView => 0xbb3244c7 => 202
	i32 3147165239, ; 498: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3147228406, ; 499: Syncfusion.Maui.Core => 0xbb96e4f6 => 196
	i32 3148237826, ; 500: GoogleGson.dll => 0xbba64c02 => 176
	i32 3159123045, ; 501: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 502: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3170039328, ; 503: Syncfusion.Maui.ListView.dll => 0xbcf2f620 => 202
	i32 3178803400, ; 504: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 255
	i32 3192346100, ; 505: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 506: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 507: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 508: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 509: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 232
	i32 3217618498, ; 510: Microsoft.VisualStudio.DesignTools.XamlTapContract => 0xbfc8f642 => 329
	i32 3220365878, ; 511: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 512: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3251039220, ; 513: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 514: Xamarin.AndroidX.CardView => 0xc235e84d => 220
	i32 3265493905, ; 515: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 516: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3277815716, ; 517: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 518: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 519: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 520: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 521: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 522: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 523: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 296
	i32 3306970809, ; 524: Syncfusion.Maui.Inputs => 0xc51c5eb9 => 201
	i32 3316684772, ; 525: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 526: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 230
	i32 3317144872, ; 527: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 528: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 218
	i32 3345895724, ; 529: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 259
	i32 3346324047, ; 530: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 256
	i32 3357674450, ; 531: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 313
	i32 3358260929, ; 532: System.Text.Json => 0xc82afec1 => 137
	i32 3362336904, ; 533: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 211
	i32 3362522851, ; 534: Xamarin.AndroidX.Core => 0xc86c06e3 => 227
	i32 3366347497, ; 535: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 536: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 260
	i32 3381016424, ; 537: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 292
	i32 3381934622, ; 538: Syncfusion.Maui.GridCommon => 0xc9943a1e => 200
	i32 3395150330, ; 539: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 540: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 541: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 231
	i32 3428513518, ; 542: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 179
	i32 3429136800, ; 543: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 544: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 545: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 234
	i32 3445260447, ; 546: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 547: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 186
	i32 3463511458, ; 548: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 300
	i32 3471940407, ; 549: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 550: Mono.Android => 0xcf3163e6 => 171
	i32 3479583265, ; 551: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 313
	i32 3484440000, ; 552: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 312
	i32 3485117614, ; 553: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 554: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 555: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 223
	i32 3509114376, ; 556: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 557: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 558: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 559: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3558305335, ; 560: Syncfusion.Maui.DataSource.dll => 0xd4176e37 => 199
	i32 3560100363, ; 561: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 562: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3580758918, ; 563: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 320
	i32 3597029428, ; 564: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 209
	i32 3598340787, ; 565: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3608519521, ; 566: System.Linq.dll => 0xd715a361 => 61
	i32 3624195450, ; 567: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 568: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 258
	i32 3633644679, ; 569: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 213
	i32 3638274909, ; 570: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 571: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 244
	i32 3643446276, ; 572: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 317
	i32 3643854240, ; 573: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 255
	i32 3645089577, ; 574: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 575: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 178
	i32 3660523487, ; 576: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 577: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3676670898, ; 578: Microsoft.Maui.Controls.HotReload.Forms => 0xdb258bb2 => 326
	i32 3682565725, ; 579: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 219
	i32 3684561358, ; 580: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 223
	i32 3697841164, ; 581: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 322
	i32 3700866549, ; 582: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 583: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 228
	i32 3716563718, ; 584: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 585: Xamarin.AndroidX.Annotation => 0xdda814c6 => 212
	i32 3724971120, ; 586: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 254
	i32 3732100267, ; 587: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 588: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 589: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 590: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3786282454, ; 591: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 221
	i32 3792276235, ; 592: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3792984670, ; 593: PMEGPCUSTOMERBank.dll => 0xe2145a5e => 0
	i32 3793321889, ; 594: AsyncAwaitBestPractices.dll => 0xe2197fa1 => 173
	i32 3800979733, ; 595: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 186
	i32 3802395368, ; 596: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3817368567, ; 597: CommunityToolkit.Maui.dll => 0xe3886bf7 => 174
	i32 3819260425, ; 598: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 599: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 600: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 601: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 180
	i32 3844307129, ; 602: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 603: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3870376305, ; 604: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 605: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 606: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 607: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 608: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 269
	i32 3888767677, ; 609: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 259
	i32 3889960447, ; 610: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 321
	i32 3896106733, ; 611: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 612: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 227
	i32 3901907137, ; 613: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920810846, ; 614: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 615: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 272
	i32 3928044579, ; 616: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 617: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 618: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 257
	i32 3945713374, ; 619: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 620: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 621: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 215
	i32 3959773229, ; 622: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 246
	i32 3980434154, ; 623: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 316
	i32 3982571493, ; 624: en-US/Syncfusion.Maui.Inputs.resources.dll => 0xed6137e5 => 325
	i32 3987592930, ; 625: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 298
	i32 4003436829, ; 626: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 627: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 214
	i32 4025784931, ; 628: System.Memory => 0xeff49a63 => 62
	i32 4030748638, ; 629: Mopups => 0xf04057de => 192
	i32 4046471985, ; 630: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 188
	i32 4054681211, ; 631: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4068434129, ; 632: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 633: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4094352644, ; 634: Microsoft.Maui.Essentials.dll => 0xf40add04 => 190
	i32 4099507663, ; 635: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 636: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 637: Xamarin.AndroidX.Emoji2 => 0xf479582c => 235
	i32 4102112229, ; 638: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 311
	i32 4125707920, ; 639: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 306
	i32 4126470640, ; 640: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 179
	i32 4127667938, ; 641: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 642: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 643: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150914736, ; 644: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 318
	i32 4151237749, ; 645: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 646: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 647: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 648: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 649: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 650: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 251
	i32 4182880526, ; 651: Microsoft.VisualStudio.DesignTools.MobileTapContracts => 0xf951b10e => 327
	i32 4185676441, ; 652: System.Security => 0xf97c5a99 => 130
	i32 4196529839, ; 653: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 654: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4256097574, ; 655: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 228
	i32 4258378803, ; 656: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 250
	i32 4260525087, ; 657: System.Buffers => 0xfdf2741f => 7
	i32 4271975918, ; 658: Microsoft.Maui.Controls.dll => 0xfea12dee => 187
	i32 4274976490, ; 659: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959, ; 660: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 251
	i32 4294763496 ; 661: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 237
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [662 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 247, ; 3
	i32 281, ; 4
	i32 48, ; 5
	i32 193, ; 6
	i32 80, ; 7
	i32 145, ; 8
	i32 30, ; 9
	i32 322, ; 10
	i32 124, ; 11
	i32 191, ; 12
	i32 102, ; 13
	i32 265, ; 14
	i32 107, ; 15
	i32 265, ; 16
	i32 139, ; 17
	i32 285, ; 18
	i32 77, ; 19
	i32 124, ; 20
	i32 13, ; 21
	i32 221, ; 22
	i32 196, ; 23
	i32 132, ; 24
	i32 267, ; 25
	i32 151, ; 26
	i32 319, ; 27
	i32 320, ; 28
	i32 18, ; 29
	i32 219, ; 30
	i32 26, ; 31
	i32 241, ; 32
	i32 1, ; 33
	i32 59, ; 34
	i32 42, ; 35
	i32 91, ; 36
	i32 224, ; 37
	i32 147, ; 38
	i32 243, ; 39
	i32 240, ; 40
	i32 291, ; 41
	i32 54, ; 42
	i32 69, ; 43
	i32 319, ; 44
	i32 210, ; 45
	i32 83, ; 46
	i32 304, ; 47
	i32 242, ; 48
	i32 303, ; 49
	i32 131, ; 50
	i32 55, ; 51
	i32 203, ; 52
	i32 197, ; 53
	i32 149, ; 54
	i32 74, ; 55
	i32 323, ; 56
	i32 145, ; 57
	i32 62, ; 58
	i32 146, ; 59
	i32 330, ; 60
	i32 165, ; 61
	i32 315, ; 62
	i32 225, ; 63
	i32 12, ; 64
	i32 238, ; 65
	i32 125, ; 66
	i32 152, ; 67
	i32 200, ; 68
	i32 113, ; 69
	i32 166, ; 70
	i32 164, ; 71
	i32 240, ; 72
	i32 253, ; 73
	i32 324, ; 74
	i32 84, ; 75
	i32 302, ; 76
	i32 296, ; 77
	i32 185, ; 78
	i32 150, ; 79
	i32 285, ; 80
	i32 60, ; 81
	i32 181, ; 82
	i32 51, ; 83
	i32 103, ; 84
	i32 114, ; 85
	i32 40, ; 86
	i32 278, ; 87
	i32 276, ; 88
	i32 120, ; 89
	i32 310, ; 90
	i32 174, ; 91
	i32 52, ; 92
	i32 44, ; 93
	i32 119, ; 94
	i32 230, ; 95
	i32 308, ; 96
	i32 236, ; 97
	i32 81, ; 98
	i32 136, ; 99
	i32 272, ; 100
	i32 217, ; 101
	i32 8, ; 102
	i32 323, ; 103
	i32 73, ; 104
	i32 290, ; 105
	i32 155, ; 106
	i32 287, ; 107
	i32 154, ; 108
	i32 203, ; 109
	i32 92, ; 110
	i32 282, ; 111
	i32 45, ; 112
	i32 305, ; 113
	i32 293, ; 114
	i32 286, ; 115
	i32 109, ; 116
	i32 129, ; 117
	i32 25, ; 118
	i32 207, ; 119
	i32 72, ; 120
	i32 55, ; 121
	i32 46, ; 122
	i32 314, ; 123
	i32 184, ; 124
	i32 231, ; 125
	i32 22, ; 126
	i32 245, ; 127
	i32 86, ; 128
	i32 43, ; 129
	i32 160, ; 130
	i32 71, ; 131
	i32 258, ; 132
	i32 3, ; 133
	i32 42, ; 134
	i32 324, ; 135
	i32 63, ; 136
	i32 16, ; 137
	i32 53, ; 138
	i32 317, ; 139
	i32 281, ; 140
	i32 105, ; 141
	i32 193, ; 142
	i32 286, ; 143
	i32 279, ; 144
	i32 242, ; 145
	i32 34, ; 146
	i32 158, ; 147
	i32 85, ; 148
	i32 32, ; 149
	i32 12, ; 150
	i32 51, ; 151
	i32 56, ; 152
	i32 262, ; 153
	i32 36, ; 154
	i32 180, ; 155
	i32 292, ; 156
	i32 280, ; 157
	i32 215, ; 158
	i32 35, ; 159
	i32 58, ; 160
	i32 249, ; 161
	i32 176, ; 162
	i32 17, ; 163
	i32 283, ; 164
	i32 164, ; 165
	i32 305, ; 166
	i32 248, ; 167
	i32 204, ; 168
	i32 183, ; 169
	i32 275, ; 170
	i32 311, ; 171
	i32 153, ; 172
	i32 271, ; 173
	i32 256, ; 174
	i32 309, ; 175
	i32 217, ; 176
	i32 29, ; 177
	i32 52, ; 178
	i32 307, ; 179
	i32 276, ; 180
	i32 5, ; 181
	i32 291, ; 182
	i32 266, ; 183
	i32 270, ; 184
	i32 222, ; 185
	i32 287, ; 186
	i32 214, ; 187
	i32 233, ; 188
	i32 85, ; 189
	i32 275, ; 190
	i32 61, ; 191
	i32 112, ; 192
	i32 57, ; 193
	i32 321, ; 194
	i32 262, ; 195
	i32 99, ; 196
	i32 19, ; 197
	i32 226, ; 198
	i32 111, ; 199
	i32 101, ; 200
	i32 102, ; 201
	i32 289, ; 202
	i32 104, ; 203
	i32 279, ; 204
	i32 71, ; 205
	i32 38, ; 206
	i32 32, ; 207
	i32 103, ; 208
	i32 73, ; 209
	i32 295, ; 210
	i32 9, ; 211
	i32 123, ; 212
	i32 46, ; 213
	i32 216, ; 214
	i32 185, ; 215
	i32 9, ; 216
	i32 43, ; 217
	i32 4, ; 218
	i32 263, ; 219
	i32 299, ; 220
	i32 0, ; 221
	i32 294, ; 222
	i32 31, ; 223
	i32 195, ; 224
	i32 138, ; 225
	i32 92, ; 226
	i32 93, ; 227
	i32 314, ; 228
	i32 49, ; 229
	i32 141, ; 230
	i32 112, ; 231
	i32 140, ; 232
	i32 232, ; 233
	i32 197, ; 234
	i32 115, ; 235
	i32 195, ; 236
	i32 280, ; 237
	i32 157, ; 238
	i32 326, ; 239
	i32 76, ; 240
	i32 79, ; 241
	i32 252, ; 242
	i32 37, ; 243
	i32 274, ; 244
	i32 175, ; 245
	i32 236, ; 246
	i32 229, ; 247
	i32 64, ; 248
	i32 138, ; 249
	i32 15, ; 250
	i32 201, ; 251
	i32 116, ; 252
	i32 268, ; 253
	i32 277, ; 254
	i32 192, ; 255
	i32 224, ; 256
	i32 48, ; 257
	i32 70, ; 258
	i32 80, ; 259
	i32 126, ; 260
	i32 94, ; 261
	i32 121, ; 262
	i32 284, ; 263
	i32 26, ; 264
	i32 245, ; 265
	i32 97, ; 266
	i32 28, ; 267
	i32 220, ; 268
	i32 312, ; 269
	i32 290, ; 270
	i32 149, ; 271
	i32 169, ; 272
	i32 4, ; 273
	i32 98, ; 274
	i32 33, ; 275
	i32 93, ; 276
	i32 267, ; 277
	i32 181, ; 278
	i32 21, ; 279
	i32 41, ; 280
	i32 198, ; 281
	i32 170, ; 282
	i32 306, ; 283
	i32 238, ; 284
	i32 298, ; 285
	i32 252, ; 286
	i32 283, ; 287
	i32 277, ; 288
	i32 257, ; 289
	i32 2, ; 290
	i32 134, ; 291
	i32 111, ; 292
	i32 328, ; 293
	i32 182, ; 294
	i32 318, ; 295
	i32 207, ; 296
	i32 315, ; 297
	i32 58, ; 298
	i32 95, ; 299
	i32 297, ; 300
	i32 39, ; 301
	i32 218, ; 302
	i32 328, ; 303
	i32 25, ; 304
	i32 94, ; 305
	i32 89, ; 306
	i32 99, ; 307
	i32 10, ; 308
	i32 87, ; 309
	i32 100, ; 310
	i32 264, ; 311
	i32 177, ; 312
	i32 173, ; 313
	i32 284, ; 314
	i32 209, ; 315
	i32 294, ; 316
	i32 7, ; 317
	i32 249, ; 318
	i32 289, ; 319
	i32 206, ; 320
	i32 88, ; 321
	i32 244, ; 322
	i32 154, ; 323
	i32 293, ; 324
	i32 33, ; 325
	i32 116, ; 326
	i32 82, ; 327
	i32 329, ; 328
	i32 20, ; 329
	i32 205, ; 330
	i32 11, ; 331
	i32 162, ; 332
	i32 3, ; 333
	i32 189, ; 334
	i32 301, ; 335
	i32 184, ; 336
	i32 182, ; 337
	i32 84, ; 338
	i32 288, ; 339
	i32 64, ; 340
	i32 303, ; 341
	i32 271, ; 342
	i32 143, ; 343
	i32 253, ; 344
	i32 157, ; 345
	i32 41, ; 346
	i32 117, ; 347
	i32 178, ; 348
	i32 208, ; 349
	i32 297, ; 350
	i32 260, ; 351
	i32 131, ; 352
	i32 75, ; 353
	i32 66, ; 354
	i32 307, ; 355
	i32 172, ; 356
	i32 212, ; 357
	i32 143, ; 358
	i32 106, ; 359
	i32 151, ; 360
	i32 70, ; 361
	i32 194, ; 362
	i32 156, ; 363
	i32 177, ; 364
	i32 121, ; 365
	i32 127, ; 366
	i32 302, ; 367
	i32 152, ; 368
	i32 235, ; 369
	i32 327, ; 370
	i32 141, ; 371
	i32 222, ; 372
	i32 325, ; 373
	i32 299, ; 374
	i32 20, ; 375
	i32 14, ; 376
	i32 135, ; 377
	i32 75, ; 378
	i32 59, ; 379
	i32 225, ; 380
	i32 167, ; 381
	i32 168, ; 382
	i32 187, ; 383
	i32 15, ; 384
	i32 74, ; 385
	i32 6, ; 386
	i32 23, ; 387
	i32 247, ; 388
	i32 206, ; 389
	i32 91, ; 390
	i32 300, ; 391
	i32 1, ; 392
	i32 136, ; 393
	i32 248, ; 394
	i32 270, ; 395
	i32 134, ; 396
	i32 69, ; 397
	i32 146, ; 398
	i32 309, ; 399
	i32 288, ; 400
	i32 239, ; 401
	i32 183, ; 402
	i32 88, ; 403
	i32 96, ; 404
	i32 229, ; 405
	i32 234, ; 406
	i32 304, ; 407
	i32 31, ; 408
	i32 45, ; 409
	i32 243, ; 410
	i32 208, ; 411
	i32 109, ; 412
	i32 158, ; 413
	i32 35, ; 414
	i32 22, ; 415
	i32 114, ; 416
	i32 57, ; 417
	i32 268, ; 418
	i32 204, ; 419
	i32 144, ; 420
	i32 118, ; 421
	i32 120, ; 422
	i32 110, ; 423
	i32 210, ; 424
	i32 139, ; 425
	i32 216, ; 426
	i32 54, ; 427
	i32 199, ; 428
	i32 105, ; 429
	i32 310, ; 430
	i32 188, ; 431
	i32 189, ; 432
	i32 133, ; 433
	i32 282, ; 434
	i32 273, ; 435
	i32 261, ; 436
	i32 316, ; 437
	i32 239, ; 438
	i32 191, ; 439
	i32 159, ; 440
	i32 295, ; 441
	i32 226, ; 442
	i32 163, ; 443
	i32 132, ; 444
	i32 261, ; 445
	i32 161, ; 446
	i32 308, ; 447
	i32 250, ; 448
	i32 205, ; 449
	i32 140, ; 450
	i32 273, ; 451
	i32 269, ; 452
	i32 169, ; 453
	i32 190, ; 454
	i32 175, ; 455
	i32 194, ; 456
	i32 211, ; 457
	i32 278, ; 458
	i32 40, ; 459
	i32 237, ; 460
	i32 81, ; 461
	i32 56, ; 462
	i32 37, ; 463
	i32 97, ; 464
	i32 166, ; 465
	i32 172, ; 466
	i32 198, ; 467
	i32 274, ; 468
	i32 82, ; 469
	i32 213, ; 470
	i32 98, ; 471
	i32 30, ; 472
	i32 159, ; 473
	i32 18, ; 474
	i32 127, ; 475
	i32 119, ; 476
	i32 233, ; 477
	i32 264, ; 478
	i32 246, ; 479
	i32 266, ; 480
	i32 165, ; 481
	i32 241, ; 482
	i32 330, ; 483
	i32 263, ; 484
	i32 254, ; 485
	i32 170, ; 486
	i32 16, ; 487
	i32 144, ; 488
	i32 301, ; 489
	i32 125, ; 490
	i32 118, ; 491
	i32 38, ; 492
	i32 115, ; 493
	i32 47, ; 494
	i32 142, ; 495
	i32 117, ; 496
	i32 202, ; 497
	i32 34, ; 498
	i32 196, ; 499
	i32 176, ; 500
	i32 95, ; 501
	i32 53, ; 502
	i32 202, ; 503
	i32 255, ; 504
	i32 129, ; 505
	i32 153, ; 506
	i32 24, ; 507
	i32 161, ; 508
	i32 232, ; 509
	i32 329, ; 510
	i32 148, ; 511
	i32 104, ; 512
	i32 89, ; 513
	i32 220, ; 514
	i32 60, ; 515
	i32 142, ; 516
	i32 100, ; 517
	i32 5, ; 518
	i32 13, ; 519
	i32 122, ; 520
	i32 135, ; 521
	i32 28, ; 522
	i32 296, ; 523
	i32 201, ; 524
	i32 72, ; 525
	i32 230, ; 526
	i32 24, ; 527
	i32 218, ; 528
	i32 259, ; 529
	i32 256, ; 530
	i32 313, ; 531
	i32 137, ; 532
	i32 211, ; 533
	i32 227, ; 534
	i32 168, ; 535
	i32 260, ; 536
	i32 292, ; 537
	i32 200, ; 538
	i32 101, ; 539
	i32 123, ; 540
	i32 231, ; 541
	i32 179, ; 542
	i32 163, ; 543
	i32 167, ; 544
	i32 234, ; 545
	i32 39, ; 546
	i32 186, ; 547
	i32 300, ; 548
	i32 17, ; 549
	i32 171, ; 550
	i32 313, ; 551
	i32 312, ; 552
	i32 137, ; 553
	i32 150, ; 554
	i32 223, ; 555
	i32 155, ; 556
	i32 130, ; 557
	i32 19, ; 558
	i32 65, ; 559
	i32 199, ; 560
	i32 147, ; 561
	i32 47, ; 562
	i32 320, ; 563
	i32 209, ; 564
	i32 79, ; 565
	i32 61, ; 566
	i32 106, ; 567
	i32 258, ; 568
	i32 213, ; 569
	i32 49, ; 570
	i32 244, ; 571
	i32 317, ; 572
	i32 255, ; 573
	i32 14, ; 574
	i32 178, ; 575
	i32 68, ; 576
	i32 171, ; 577
	i32 326, ; 578
	i32 219, ; 579
	i32 223, ; 580
	i32 322, ; 581
	i32 78, ; 582
	i32 228, ; 583
	i32 108, ; 584
	i32 212, ; 585
	i32 254, ; 586
	i32 67, ; 587
	i32 63, ; 588
	i32 27, ; 589
	i32 160, ; 590
	i32 221, ; 591
	i32 10, ; 592
	i32 0, ; 593
	i32 173, ; 594
	i32 186, ; 595
	i32 11, ; 596
	i32 174, ; 597
	i32 78, ; 598
	i32 126, ; 599
	i32 83, ; 600
	i32 180, ; 601
	i32 66, ; 602
	i32 107, ; 603
	i32 65, ; 604
	i32 128, ; 605
	i32 122, ; 606
	i32 77, ; 607
	i32 269, ; 608
	i32 259, ; 609
	i32 321, ; 610
	i32 8, ; 611
	i32 227, ; 612
	i32 2, ; 613
	i32 44, ; 614
	i32 272, ; 615
	i32 156, ; 616
	i32 128, ; 617
	i32 257, ; 618
	i32 23, ; 619
	i32 133, ; 620
	i32 215, ; 621
	i32 246, ; 622
	i32 316, ; 623
	i32 325, ; 624
	i32 298, ; 625
	i32 29, ; 626
	i32 214, ; 627
	i32 62, ; 628
	i32 192, ; 629
	i32 188, ; 630
	i32 90, ; 631
	i32 87, ; 632
	i32 148, ; 633
	i32 190, ; 634
	i32 36, ; 635
	i32 86, ; 636
	i32 235, ; 637
	i32 311, ; 638
	i32 306, ; 639
	i32 179, ; 640
	i32 50, ; 641
	i32 6, ; 642
	i32 90, ; 643
	i32 318, ; 644
	i32 21, ; 645
	i32 162, ; 646
	i32 96, ; 647
	i32 50, ; 648
	i32 113, ; 649
	i32 251, ; 650
	i32 327, ; 651
	i32 130, ; 652
	i32 76, ; 653
	i32 27, ; 654
	i32 228, ; 655
	i32 250, ; 656
	i32 7, ; 657
	i32 187, ; 658
	i32 110, ; 659
	i32 251, ; 660
	i32 237 ; 661
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ 82d8938cf80f6d5fa6c28529ddfbdb753d805ab4"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
