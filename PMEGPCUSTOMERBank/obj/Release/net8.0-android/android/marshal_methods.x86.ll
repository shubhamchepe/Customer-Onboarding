; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [158 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [316 x i32] [
	i32 39109920, ; 0: Newtonsoft.Json.dll => 0x254c520 => 55
	i32 42639949, ; 1: System.Threading.Thread => 0x28aa24d => 147
	i32 67008169, ; 2: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 72070932, ; 3: Microsoft.Maui.Graphics.dll => 0x44bb714 => 53
	i32 117431740, ; 4: System.Runtime.InteropServices => 0x6ffddbc => 135
	i32 159306688, ; 5: System.ComponentModel.Annotations => 0x97ed3c0 => 104
	i32 165246403, ; 6: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 73
	i32 172961045, ; 7: Syncfusion.Maui.Core.dll => 0xa4f2d15 => 58
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 91
	i32 195452805, ; 9: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 30
	i32 199333315, ; 10: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 31
	i32 205061960, ; 11: System.ComponentModel => 0xc38ff48 => 107
	i32 209399409, ; 12: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 71
	i32 230752869, ; 13: Microsoft.CSharp.dll => 0xdc10265 => 98
	i32 231409092, ; 14: System.Linq.Parallel => 0xdcb05c4 => 118
	i32 246610117, ; 15: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 132
	i32 280992041, ; 16: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 2
	i32 317674968, ; 17: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 18: Xamarin.AndroidX.Activity.dll => 0x13031348 => 68
	i32 336156722, ; 19: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 15
	i32 342366114, ; 20: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 80
	i32 356389973, ; 21: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 14
	i32 374376850, ; 22: Syncfusion.Maui.Popup.dll => 0x16508992 => 65
	i32 374794515, ; 23: Syncfusion.Maui.Data.dll => 0x1656e913 => 59
	i32 376991480, ; 24: en-US/Syncfusion.Maui.Buttons.resources.dll => 0x16786ef8 => 34
	i32 379916513, ; 25: System.Threading.Thread.dll => 0x16a510e1 => 147
	i32 385762202, ; 26: System.Memory.dll => 0x16fe439a => 121
	i32 395744057, ; 27: _Microsoft.Android.Resource.Designer => 0x17969339 => 37
	i32 435591531, ; 28: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 26
	i32 442565967, ; 29: System.Collections => 0x1a61054f => 103
	i32 450948140, ; 30: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 79
	i32 456681651, ; 31: Syncfusion.Maui.GridCommon.dll => 0x1b3868b3 => 62
	i32 459347974, ; 32: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 139
	i32 469710990, ; 33: System.dll => 0x1bff388e => 152
	i32 488065789, ; 34: en-US/Syncfusion.Maui.DataGrid.resources.dll => 0x1d174afd => 35
	i32 498788369, ; 35: System.ObjectModel => 0x1dbae811 => 126
	i32 500358224, ; 36: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 13
	i32 503918385, ; 37: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 7
	i32 513247710, ; 38: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 48
	i32 530272170, ; 39: System.Linq.Queryable => 0x1f9b4faa => 119
	i32 539058512, ; 40: Microsoft.Extensions.Logging => 0x20216150 => 45
	i32 546455878, ; 41: System.Runtime.Serialization.Xml => 0x20924146 => 140
	i32 592146354, ; 42: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 21
	i32 597488923, ; 43: CommunityToolkit.Maui => 0x239cf51b => 39
	i32 627609679, ; 44: Xamarin.AndroidX.CustomView => 0x2568904f => 77
	i32 627931235, ; 45: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 662205335, ; 46: System.Text.Encodings.Web.dll => 0x27787397 => 144
	i32 672442732, ; 47: System.Collections.Concurrent => 0x2814a96c => 99
	i32 676419328, ; 48: en-US\Syncfusion.Maui.Buttons.resources => 0x28515700 => 34
	i32 688181140, ; 49: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 1
	i32 690569205, ; 50: System.Xml.Linq.dll => 0x29293ff5 => 149
	i32 695450347, ; 51: Syncfusion.Maui.Popup => 0x2973baeb => 65
	i32 699345723, ; 52: System.Reflection.Emit => 0x29af2b3b => 133
	i32 706645707, ; 53: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 16
	i32 709557578, ; 54: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 4
	i32 722857257, ; 55: System.Runtime.Loader.dll => 0x2b15ed29 => 136
	i32 759454413, ; 56: System.Net.Requests => 0x2d445acd => 124
	i32 775507847, ; 57: System.IO.Compression => 0x2e394f87 => 116
	i32 777317022, ; 58: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 789151979, ; 59: Microsoft.Extensions.Options => 0x2f0980eb => 47
	i32 804715423, ; 60: System.Data.Common => 0x2ff6fb9f => 109
	i32 823281589, ; 61: System.Private.Uri.dll => 0x311247b5 => 128
	i32 830298997, ; 62: System.IO.Compression.Brotli => 0x317d5b75 => 115
	i32 878833237, ; 63: en-US\Syncfusion.Maui.DataGrid.resources => 0x3461ee55 => 35
	i32 904024072, ; 64: System.ComponentModel.Primitives.dll => 0x35e25008 => 105
	i32 926902833, ; 65: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 28
	i32 955402788, ; 66: Newtonsoft.Json => 0x38f24a24 => 55
	i32 967690846, ; 67: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 80
	i32 975874589, ; 68: System.Xml.XDocument => 0x3a2aaa1d => 151
	i32 986514023, ; 69: System.Private.DataContractSerialization.dll => 0x3acd0267 => 127
	i32 992768348, ; 70: System.Collections.dll => 0x3b2c715c => 103
	i32 1012816738, ; 71: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 90
	i32 1019214401, ; 72: System.Drawing => 0x3cbffa41 => 114
	i32 1028951442, ; 73: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 44
	i32 1029334545, ; 74: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 3
	i32 1035644815, ; 75: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 69
	i32 1036536393, ; 76: System.Drawing.Primitives.dll => 0x3dc84a49 => 113
	i32 1044663988, ; 77: System.Linq.Expressions.dll => 0x3e444eb4 => 117
	i32 1052210849, ; 78: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 82
	i32 1082857460, ; 79: System.ComponentModel.TypeConverter => 0x408b17f4 => 106
	i32 1084122840, ; 80: Xamarin.Kotlin.StdLib => 0x409e66d8 => 95
	i32 1098259244, ; 81: System => 0x41761b2c => 152
	i32 1118262833, ; 82: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1126950560, ; 83: Syncfusion.Maui.PullToRefresh.dll => 0x432be6a0 => 66
	i32 1168523401, ; 84: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1178241025, ; 85: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 87
	i32 1203215381, ; 86: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 20
	i32 1208641965, ; 87: System.Diagnostics.Process => 0x480a69ad => 111
	i32 1234928153, ; 88: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 18
	i32 1260983243, ; 89: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1293217323, ; 90: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 78
	i32 1309188875, ; 91: System.Private.DataContractSerialization => 0x4e08a30b => 127
	i32 1324164729, ; 92: System.Linq => 0x4eed2679 => 120
	i32 1373134921, ; 93: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 94: Xamarin.AndroidX.SavedState => 0x52114ed3 => 90
	i32 1406073936, ; 95: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 74
	i32 1408764838, ; 96: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 138
	i32 1430672901, ; 97: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1461004990, ; 98: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1461234159, ; 99: System.Collections.Immutable.dll => 0x5718a9ef => 100
	i32 1462112819, ; 100: System.IO.Compression.dll => 0x57261233 => 116
	i32 1469204771, ; 101: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 70
	i32 1470490898, ; 102: Microsoft.Extensions.Primitives => 0x57a5e912 => 48
	i32 1479771757, ; 103: System.Collections.Immutable => 0x5833866d => 100
	i32 1480492111, ; 104: System.IO.Compression.Brotli.dll => 0x583e844f => 115
	i32 1493001747, ; 105: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 10
	i32 1508333500, ; 106: PMEGPCUSTOMERBank => 0x59e757bc => 97
	i32 1514721132, ; 107: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 5
	i32 1537889881, ; 108: Syncfusion.Maui.Buttons.dll => 0x5baa5659 => 57
	i32 1543031311, ; 109: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 146
	i32 1543355203, ; 110: System.Reflection.Emit.dll => 0x5bfdbb43 => 133
	i32 1551623176, ; 111: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 25
	i32 1589115732, ; 112: Syncfusion.Maui.Data => 0x5eb7fb54 => 59
	i32 1596911864, ; 113: Syncfusion.Maui.Buttons => 0x5f2ef0f8 => 57
	i32 1622152042, ; 114: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 84
	i32 1624863272, ; 115: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 93
	i32 1634654947, ; 116: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 40
	i32 1636350590, ; 117: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 76
	i32 1639515021, ; 118: System.Net.Http.dll => 0x61b9038d => 122
	i32 1639986890, ; 119: System.Text.RegularExpressions => 0x61c036ca => 146
	i32 1653151792, ; 120: Syncfusion.Maui.Inputs.dll => 0x62891830 => 63
	i32 1657153582, ; 121: System.Runtime => 0x62c6282e => 141
	i32 1658251792, ; 122: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 94
	i32 1667453763, ; 123: Mopups.dll => 0x63635343 => 54
	i32 1677501392, ; 124: System.Net.Primitives.dll => 0x63fca3d0 => 123
	i32 1679769178, ; 125: System.Security.Cryptography => 0x641f3e5a => 142
	i32 1729485958, ; 126: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 72
	i32 1736233607, ; 127: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 23
	i32 1743415430, ; 128: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1763938596, ; 129: System.Diagnostics.TraceSource.dll => 0x69239124 => 112
	i32 1766324549, ; 130: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 91
	i32 1770582343, ; 131: Microsoft.Extensions.Logging.dll => 0x6988f147 => 45
	i32 1779859068, ; 132: Syncfusion.Maui.DataGrid.dll => 0x6a167e7c => 60
	i32 1780572499, ; 133: Mono.Android.Runtime.dll => 0x6a216153 => 156
	i32 1782862114, ; 134: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 135: Xamarin.AndroidX.Fragment => 0x6a96652d => 79
	i32 1793755602, ; 136: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1808609942, ; 137: Xamarin.AndroidX.Loader => 0x6bcd3296 => 84
	i32 1813058853, ; 138: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 95
	i32 1813201214, ; 139: Xamarin.Google.Android.Material => 0x6c13413e => 94
	i32 1818569960, ; 140: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 88
	i32 1824175904, ; 141: System.Text.Encoding.Extensions => 0x6cbab720 => 143
	i32 1824722060, ; 142: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 138
	i32 1828688058, ; 143: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 46
	i32 1842015223, ; 144: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 29
	i32 1853025655, ; 145: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 146: System.Linq.Expressions => 0x6ec71a65 => 117
	i32 1870277092, ; 147: System.Reflection.Primitives => 0x6f7a29e4 => 134
	i32 1875935024, ; 148: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1910275211, ; 149: System.Collections.NonGeneric.dll => 0x71dc7c8b => 101
	i32 1939592360, ; 150: System.Private.Xml.Linq => 0x739bd4a8 => 129
	i32 1968388702, ; 151: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 41
	i32 1968499395, ; 152: AsyncAwaitBestPractices => 0x7554eac3 => 38
	i32 2003115576, ; 153: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2019465201, ; 154: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 82
	i32 2025202353, ; 155: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 0
	i32 2045470958, ; 156: System.Private.Xml => 0x79eb68ee => 130
	i32 2055257422, ; 157: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 81
	i32 2066184531, ; 158: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2070888862, ; 159: System.Diagnostics.TraceSource => 0x7b6f419e => 112
	i32 2079903147, ; 160: System.Runtime.dll => 0x7bf8cdab => 141
	i32 2090596640, ; 161: System.Numerics.Vectors => 0x7c9bf920 => 125
	i32 2127167465, ; 162: System.Console => 0x7ec9ffe9 => 108
	i32 2134827680, ; 163: Syncfusion.Maui.Sliders.dll => 0x7f3ee2a0 => 67
	i32 2142473426, ; 164: System.Collections.Specialized => 0x7fb38cd2 => 102
	i32 2159891885, ; 165: Microsoft.Maui => 0x80bd55ad => 51
	i32 2169148018, ; 166: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2181898931, ; 167: Microsoft.Extensions.Options.dll => 0x820d22b3 => 47
	i32 2192057212, ; 168: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 46
	i32 2193016926, ; 169: System.ObjectModel.dll => 0x82b6c85e => 126
	i32 2201107256, ; 170: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 96
	i32 2201231467, ; 171: System.Net.Http => 0x8334206b => 122
	i32 2207618523, ; 172: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2266799131, ; 173: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 42
	i32 2270573516, ; 174: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 8
	i32 2279755925, ; 175: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 89
	i32 2303942373, ; 176: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 177: System.Private.CoreLib.dll => 0x896b7878 => 154
	i32 2353062107, ; 178: System.Net.Primitives => 0x8c40e0db => 123
	i32 2354730003, ; 179: Syncfusion.Licensing => 0x8c5a5413 => 56
	i32 2368005991, ; 180: System.Xml.ReaderWriter.dll => 0x8d24e767 => 150
	i32 2371007202, ; 181: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 41
	i32 2395872292, ; 182: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2426750280, ; 183: en-US\Syncfusion.Maui.Inputs.resources => 0x90a54548 => 36
	i32 2427813419, ; 184: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 185: System.Console.dll => 0x912896e5 => 108
	i32 2459001652, ; 186: System.Linq.Parallel.dll => 0x92916334 => 118
	i32 2471841756, ; 187: netstandard.dll => 0x93554fdc => 153
	i32 2475788418, ; 188: Java.Interop.dll => 0x93918882 => 155
	i32 2480646305, ; 189: Microsoft.Maui.Controls => 0x93dba8a1 => 49
	i32 2538310050, ; 190: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 132
	i32 2550873716, ; 191: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2562349572, ; 192: Microsoft.CSharp => 0x98ba5a04 => 98
	i32 2570120770, ; 193: System.Text.Encodings.Web => 0x9930ee42 => 144
	i32 2585220780, ; 194: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 143
	i32 2593496499, ; 195: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2605712449, ; 196: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 96
	i32 2617129537, ; 197: System.Private.Xml.dll => 0x9bfe3a41 => 130
	i32 2620871830, ; 198: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 76
	i32 2626831493, ; 199: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2663698177, ; 200: System.Runtime.Loader => 0x9ec4cf01 => 136
	i32 2664396074, ; 201: System.Xml.XDocument.dll => 0x9ecf752a => 151
	i32 2665622720, ; 202: System.Drawing.Primitives => 0x9ee22cc0 => 113
	i32 2676780864, ; 203: System.Data.Common.dll => 0x9f8c6f40 => 109
	i32 2686887180, ; 204: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 140
	i32 2707746672, ; 205: Syncfusion.Maui.PullToRefresh => 0xa164ef70 => 66
	i32 2724373263, ; 206: System.Runtime.Numerics.dll => 0xa262a30f => 137
	i32 2732626843, ; 207: Xamarin.AndroidX.Activity => 0xa2e0939b => 68
	i32 2737747696, ; 208: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 70
	i32 2743368605, ; 209: Syncfusion.Maui.DataSource => 0xa3847b9d => 61
	i32 2752995522, ; 210: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 211: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 50
	i32 2764765095, ; 212: Microsoft.Maui.dll => 0xa4caf7a7 => 51
	i32 2778768386, ; 213: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 92
	i32 2785988530, ; 214: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2801831435, ; 215: Microsoft.Maui.Graphics => 0xa7008e0b => 53
	i32 2806116107, ; 216: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 6
	i32 2810250172, ; 217: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 74
	i32 2831556043, ; 218: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 19
	i32 2842426040, ; 219: Syncfusion.Maui.Sliders => 0xa96bfab8 => 67
	i32 2853208004, ; 220: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 92
	i32 2861189240, ; 221: Microsoft.Maui.Essentials => 0xaa8a4878 => 52
	i32 2868488919, ; 222: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 40
	i32 2868557005, ; 223: Syncfusion.Licensing.dll => 0xaafab4cd => 56
	i32 2909740682, ; 224: System.Private.CoreLib => 0xad6f1e8a => 154
	i32 2915140907, ; 225: Syncfusion.Maui.DataGrid => 0xadc1852b => 60
	i32 2916838712, ; 226: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 93
	i32 2919462931, ; 227: System.Numerics.Vectors.dll => 0xae037813 => 125
	i32 2959614098, ; 228: System.ComponentModel.dll => 0xb0682092 => 107
	i32 2978675010, ; 229: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 78
	i32 3038032645, ; 230: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 37
	i32 3057625584, ; 231: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 85
	i32 3059408633, ; 232: Mono.Android.Runtime => 0xb65adef9 => 156
	i32 3059793426, ; 233: System.ComponentModel.Primitives => 0xb660be12 => 105
	i32 3077302341, ; 234: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 12
	i32 3140633799, ; 235: Syncfusion.Maui.ListView => 0xbb3244c7 => 64
	i32 3147228406, ; 236: Syncfusion.Maui.Core => 0xbb96e4f6 => 58
	i32 3159123045, ; 237: System.Reflection.Primitives.dll => 0xbc4c6465 => 134
	i32 3170039328, ; 238: Syncfusion.Maui.ListView.dll => 0xbcf2f620 => 64
	i32 3178803400, ; 239: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 86
	i32 3220365878, ; 240: System.Threading => 0xbff2e236 => 148
	i32 3258312781, ; 241: Xamarin.AndroidX.CardView => 0xc235e84d => 72
	i32 3265493905, ; 242: System.Linq.Queryable.dll => 0xc2a37b91 => 119
	i32 3280506390, ; 243: System.ComponentModel.Annotations.dll => 0xc3888e16 => 104
	i32 3305363605, ; 244: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3306970809, ; 245: Syncfusion.Maui.Inputs => 0xc51c5eb9 => 63
	i32 3316684772, ; 246: System.Net.Requests.dll => 0xc5b097e4 => 124
	i32 3317135071, ; 247: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 77
	i32 3346324047, ; 248: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 87
	i32 3357674450, ; 249: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3358260929, ; 250: System.Text.Json => 0xc82afec1 => 145
	i32 3362522851, ; 251: Xamarin.AndroidX.Core => 0xc86c06e3 => 75
	i32 3366347497, ; 252: Java.Interop => 0xc8a662e9 => 155
	i32 3374999561, ; 253: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 89
	i32 3381016424, ; 254: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3381934622, ; 255: Syncfusion.Maui.GridCommon => 0xc9943a1e => 62
	i32 3428513518, ; 256: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 43
	i32 3430777524, ; 257: netstandard => 0xcc7d82b4 => 153
	i32 3463511458, ; 258: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 11
	i32 3471940407, ; 259: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 106
	i32 3476120550, ; 260: Mono.Android => 0xcf3163e6 => 157
	i32 3479583265, ; 261: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 24
	i32 3484440000, ; 262: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3485117614, ; 263: System.Text.Json.dll => 0xcfbaacae => 145
	i32 3509114376, ; 264: System.Xml.Linq => 0xd128d608 => 149
	i32 3558305335, ; 265: Syncfusion.Maui.DataSource.dll => 0xd4176e37 => 61
	i32 3580758918, ; 266: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3608519521, ; 267: System.Linq.dll => 0xd715a361 => 120
	i32 3641597786, ; 268: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 81
	i32 3643446276, ; 269: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 270: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 86
	i32 3657292374, ; 271: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 42
	i32 3672681054, ; 272: Mono.Android.dll => 0xdae8aa5e => 157
	i32 3682565725, ; 273: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 71
	i32 3697841164, ; 274: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 33
	i32 3724971120, ; 275: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 85
	i32 3748608112, ; 276: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 110
	i32 3786282454, ; 277: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 73
	i32 3792276235, ; 278: System.Collections.NonGeneric => 0xe2098b0b => 101
	i32 3792984670, ; 279: PMEGPCUSTOMERBank.dll => 0xe2145a5e => 97
	i32 3793321889, ; 280: AsyncAwaitBestPractices.dll => 0xe2197fa1 => 38
	i32 3802395368, ; 281: System.Collections.Specialized.dll => 0xe2a3f2e8 => 102
	i32 3817368567, ; 282: CommunityToolkit.Maui.dll => 0xe3886bf7 => 39
	i32 3823082795, ; 283: System.Security.Cryptography.dll => 0xe3df9d2b => 142
	i32 3841636137, ; 284: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 44
	i32 3849253459, ; 285: System.Runtime.InteropServices.dll => 0xe56ef253 => 135
	i32 3889960447, ; 286: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 32
	i32 3896106733, ; 287: System.Collections.Concurrent.dll => 0xe839deed => 99
	i32 3896760992, ; 288: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 75
	i32 3928044579, ; 289: System.Xml.ReaderWriter => 0xea213423 => 150
	i32 3931092270, ; 290: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 88
	i32 3955647286, ; 291: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 69
	i32 3980434154, ; 292: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 27
	i32 3982571493, ; 293: en-US/Syncfusion.Maui.Inputs.resources.dll => 0xed6137e5 => 36
	i32 3987592930, ; 294: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 9
	i32 4003436829, ; 295: System.Diagnostics.Process.dll => 0xee9f991d => 111
	i32 4025784931, ; 296: System.Memory => 0xeff49a63 => 121
	i32 4030748638, ; 297: Mopups => 0xf04057de => 54
	i32 4046471985, ; 298: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 50
	i32 4054681211, ; 299: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 131
	i32 4068434129, ; 300: System.Private.Xml.Linq.dll => 0xf27f60d1 => 129
	i32 4073602200, ; 301: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4094352644, ; 302: Microsoft.Maui.Essentials.dll => 0xf40add04 => 52
	i32 4099507663, ; 303: System.Drawing.dll => 0xf45985cf => 114
	i32 4100113165, ; 304: System.Private.Uri => 0xf462c30d => 128
	i32 4102112229, ; 305: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 22
	i32 4125707920, ; 306: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 17
	i32 4126470640, ; 307: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 43
	i32 4147896353, ; 308: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 131
	i32 4150914736, ; 309: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4181436372, ; 310: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 139
	i32 4182413190, ; 311: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 83
	i32 4213026141, ; 312: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 110
	i32 4271975918, ; 313: Microsoft.Maui.Controls.dll => 0xfea12dee => 49
	i32 4274976490, ; 314: System.Runtime.Numerics => 0xfecef6ea => 137
	i32 4292120959 ; 315: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 83
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [316 x i32] [
	i32 55, ; 0
	i32 147, ; 1
	i32 33, ; 2
	i32 53, ; 3
	i32 135, ; 4
	i32 104, ; 5
	i32 73, ; 6
	i32 58, ; 7
	i32 91, ; 8
	i32 30, ; 9
	i32 31, ; 10
	i32 107, ; 11
	i32 71, ; 12
	i32 98, ; 13
	i32 118, ; 14
	i32 132, ; 15
	i32 2, ; 16
	i32 30, ; 17
	i32 68, ; 18
	i32 15, ; 19
	i32 80, ; 20
	i32 14, ; 21
	i32 65, ; 22
	i32 59, ; 23
	i32 34, ; 24
	i32 147, ; 25
	i32 121, ; 26
	i32 37, ; 27
	i32 26, ; 28
	i32 103, ; 29
	i32 79, ; 30
	i32 62, ; 31
	i32 139, ; 32
	i32 152, ; 33
	i32 35, ; 34
	i32 126, ; 35
	i32 13, ; 36
	i32 7, ; 37
	i32 48, ; 38
	i32 119, ; 39
	i32 45, ; 40
	i32 140, ; 41
	i32 21, ; 42
	i32 39, ; 43
	i32 77, ; 44
	i32 19, ; 45
	i32 144, ; 46
	i32 99, ; 47
	i32 34, ; 48
	i32 1, ; 49
	i32 149, ; 50
	i32 65, ; 51
	i32 133, ; 52
	i32 16, ; 53
	i32 4, ; 54
	i32 136, ; 55
	i32 124, ; 56
	i32 116, ; 57
	i32 25, ; 58
	i32 47, ; 59
	i32 109, ; 60
	i32 128, ; 61
	i32 115, ; 62
	i32 35, ; 63
	i32 105, ; 64
	i32 28, ; 65
	i32 55, ; 66
	i32 80, ; 67
	i32 151, ; 68
	i32 127, ; 69
	i32 103, ; 70
	i32 90, ; 71
	i32 114, ; 72
	i32 44, ; 73
	i32 3, ; 74
	i32 69, ; 75
	i32 113, ; 76
	i32 117, ; 77
	i32 82, ; 78
	i32 106, ; 79
	i32 95, ; 80
	i32 152, ; 81
	i32 16, ; 82
	i32 66, ; 83
	i32 22, ; 84
	i32 87, ; 85
	i32 20, ; 86
	i32 111, ; 87
	i32 18, ; 88
	i32 2, ; 89
	i32 78, ; 90
	i32 127, ; 91
	i32 120, ; 92
	i32 32, ; 93
	i32 90, ; 94
	i32 74, ; 95
	i32 138, ; 96
	i32 0, ; 97
	i32 6, ; 98
	i32 100, ; 99
	i32 116, ; 100
	i32 70, ; 101
	i32 48, ; 102
	i32 100, ; 103
	i32 115, ; 104
	i32 10, ; 105
	i32 97, ; 106
	i32 5, ; 107
	i32 57, ; 108
	i32 146, ; 109
	i32 133, ; 110
	i32 25, ; 111
	i32 59, ; 112
	i32 57, ; 113
	i32 84, ; 114
	i32 93, ; 115
	i32 40, ; 116
	i32 76, ; 117
	i32 122, ; 118
	i32 146, ; 119
	i32 63, ; 120
	i32 141, ; 121
	i32 94, ; 122
	i32 54, ; 123
	i32 123, ; 124
	i32 142, ; 125
	i32 72, ; 126
	i32 23, ; 127
	i32 1, ; 128
	i32 112, ; 129
	i32 91, ; 130
	i32 45, ; 131
	i32 60, ; 132
	i32 156, ; 133
	i32 17, ; 134
	i32 79, ; 135
	i32 9, ; 136
	i32 84, ; 137
	i32 95, ; 138
	i32 94, ; 139
	i32 88, ; 140
	i32 143, ; 141
	i32 138, ; 142
	i32 46, ; 143
	i32 29, ; 144
	i32 26, ; 145
	i32 117, ; 146
	i32 134, ; 147
	i32 8, ; 148
	i32 101, ; 149
	i32 129, ; 150
	i32 41, ; 151
	i32 38, ; 152
	i32 5, ; 153
	i32 82, ; 154
	i32 0, ; 155
	i32 130, ; 156
	i32 81, ; 157
	i32 4, ; 158
	i32 112, ; 159
	i32 141, ; 160
	i32 125, ; 161
	i32 108, ; 162
	i32 67, ; 163
	i32 102, ; 164
	i32 51, ; 165
	i32 12, ; 166
	i32 47, ; 167
	i32 46, ; 168
	i32 126, ; 169
	i32 96, ; 170
	i32 122, ; 171
	i32 14, ; 172
	i32 42, ; 173
	i32 8, ; 174
	i32 89, ; 175
	i32 18, ; 176
	i32 154, ; 177
	i32 123, ; 178
	i32 56, ; 179
	i32 150, ; 180
	i32 41, ; 181
	i32 13, ; 182
	i32 36, ; 183
	i32 10, ; 184
	i32 108, ; 185
	i32 118, ; 186
	i32 153, ; 187
	i32 155, ; 188
	i32 49, ; 189
	i32 132, ; 190
	i32 11, ; 191
	i32 98, ; 192
	i32 144, ; 193
	i32 143, ; 194
	i32 20, ; 195
	i32 96, ; 196
	i32 130, ; 197
	i32 76, ; 198
	i32 15, ; 199
	i32 136, ; 200
	i32 151, ; 201
	i32 113, ; 202
	i32 109, ; 203
	i32 140, ; 204
	i32 66, ; 205
	i32 137, ; 206
	i32 68, ; 207
	i32 70, ; 208
	i32 61, ; 209
	i32 21, ; 210
	i32 50, ; 211
	i32 51, ; 212
	i32 92, ; 213
	i32 27, ; 214
	i32 53, ; 215
	i32 6, ; 216
	i32 74, ; 217
	i32 19, ; 218
	i32 67, ; 219
	i32 92, ; 220
	i32 52, ; 221
	i32 40, ; 222
	i32 56, ; 223
	i32 154, ; 224
	i32 60, ; 225
	i32 93, ; 226
	i32 125, ; 227
	i32 107, ; 228
	i32 78, ; 229
	i32 37, ; 230
	i32 85, ; 231
	i32 156, ; 232
	i32 105, ; 233
	i32 12, ; 234
	i32 64, ; 235
	i32 58, ; 236
	i32 134, ; 237
	i32 64, ; 238
	i32 86, ; 239
	i32 148, ; 240
	i32 72, ; 241
	i32 119, ; 242
	i32 104, ; 243
	i32 7, ; 244
	i32 63, ; 245
	i32 124, ; 246
	i32 77, ; 247
	i32 87, ; 248
	i32 24, ; 249
	i32 145, ; 250
	i32 75, ; 251
	i32 155, ; 252
	i32 89, ; 253
	i32 3, ; 254
	i32 62, ; 255
	i32 43, ; 256
	i32 153, ; 257
	i32 11, ; 258
	i32 106, ; 259
	i32 157, ; 260
	i32 24, ; 261
	i32 23, ; 262
	i32 145, ; 263
	i32 149, ; 264
	i32 61, ; 265
	i32 31, ; 266
	i32 120, ; 267
	i32 81, ; 268
	i32 28, ; 269
	i32 86, ; 270
	i32 42, ; 271
	i32 157, ; 272
	i32 71, ; 273
	i32 33, ; 274
	i32 85, ; 275
	i32 110, ; 276
	i32 73, ; 277
	i32 101, ; 278
	i32 97, ; 279
	i32 38, ; 280
	i32 102, ; 281
	i32 39, ; 282
	i32 142, ; 283
	i32 44, ; 284
	i32 135, ; 285
	i32 32, ; 286
	i32 99, ; 287
	i32 75, ; 288
	i32 150, ; 289
	i32 88, ; 290
	i32 69, ; 291
	i32 27, ; 292
	i32 36, ; 293
	i32 9, ; 294
	i32 111, ; 295
	i32 121, ; 296
	i32 54, ; 297
	i32 50, ; 298
	i32 131, ; 299
	i32 129, ; 300
	i32 148, ; 301
	i32 52, ; 302
	i32 114, ; 303
	i32 128, ; 304
	i32 22, ; 305
	i32 17, ; 306
	i32 43, ; 307
	i32 131, ; 308
	i32 29, ; 309
	i32 139, ; 310
	i32 83, ; 311
	i32 110, ; 312
	i32 49, ; 313
	i32 137, ; 314
	i32 83 ; 315
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
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

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
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
