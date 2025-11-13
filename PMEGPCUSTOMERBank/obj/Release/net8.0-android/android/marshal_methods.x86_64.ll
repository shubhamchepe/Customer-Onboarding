; ModuleID = 'marshal_methods.x86_64.ll'
source_filename = "marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [158 x ptr] zeroinitializer, align 16

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [316 x i64] [
	i64 98382396393917666, ; 0: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 48
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 157
	i64 131669012237370309, ; 2: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 52
	i64 196720943101637631, ; 3: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 117
	i64 210515253464952879, ; 4: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 73
	i64 232391251801502327, ; 5: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 90
	i64 267080112704573687, ; 6: Syncfusion.Maui.Data.dll => 0x3b4dbf28c53d0f7 => 59
	i64 545109961164950392, ; 7: fi/Microsoft.Maui.Controls.resources.dll => 0x7909e9f1ec38b78 => 7
	i64 560278790331054453, ; 8: System.Reflection.Primitives => 0x7c6829760de3975 => 134
	i64 750875890346172408, ; 9: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 147
	i64 799765834175365804, ; 10: System.ComponentModel.dll => 0xb1956c9f18442ac => 107
	i64 849051935479314978, ; 11: hi/Microsoft.Maui.Controls.resources.dll => 0xbc8703ca21a3a22 => 10
	i64 872800313462103108, ; 12: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 78
	i64 1010599046655515943, ; 13: System.Reflection.Primitives.dll => 0xe065e7a82401d27 => 134
	i64 1120440138749646132, ; 14: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 94
	i64 1121665720830085036, ; 15: nb/Microsoft.Maui.Controls.resources.dll => 0xf90f507becf47ac => 18
	i64 1168642086743967698, ; 16: Syncfusion.Maui.Buttons.dll => 0x1037d9c941f207d2 => 57
	i64 1268860745194512059, ; 17: System.Drawing.dll => 0x119be62002c19ebb => 114
	i64 1369545283391376210, ; 18: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 86
	i64 1476839205573959279, ; 19: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 123
	i64 1486715745332614827, ; 20: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 49
	i64 1513467482682125403, ; 21: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 156
	i64 1537168428375924959, ; 22: System.Threading.Thread.dll => 0x15551e8a954ae0df => 147
	i64 1556147632182429976, ; 23: ko/Microsoft.Maui.Controls.resources.dll => 0x15988c06d24c8918 => 16
	i64 1624659445732251991, ; 24: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 70
	i64 1628611045998245443, ; 25: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 83
	i64 1731380447121279447, ; 26: Newtonsoft.Json => 0x18071957e9b889d7 => 55
	i64 1743969030606105336, ; 27: System.Memory.dll => 0x1833d297e88f2af8 => 121
	i64 1767386781656293639, ; 28: System.Private.Uri.dll => 0x188704e9f5582107 => 128
	i64 1795316252682057001, ; 29: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 69
	i64 1835311033149317475, ; 30: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 6
	i64 1836611346387731153, ; 31: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 90
	i64 1875417405349196092, ; 32: System.Drawing.Primitives => 0x1a06d2319b6c713c => 113
	i64 1881198190668717030, ; 33: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 28
	i64 1920760634179481754, ; 34: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 50
	i64 1959996714666907089, ; 35: tr/Microsoft.Maui.Controls.resources.dll => 0x1b334ea0a2a755d1 => 28
	i64 1981742497975770890, ; 36: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 82
	i64 1983698669889758782, ; 37: cs/Microsoft.Maui.Controls.resources.dll => 0x1b87836e2031a63e => 2
	i64 2019660174692588140, ; 38: pl/Microsoft.Maui.Controls.resources.dll => 0x1c07463a6f8e1a6c => 20
	i64 2102659300918482391, ; 39: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 113
	i64 2133195048986300728, ; 40: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 55
	i64 2165725771938924357, ; 41: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 71
	i64 2262844636196693701, ; 42: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 78
	i64 2287834202362508563, ; 43: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 99
	i64 2302323944321350744, ; 44: ru/Microsoft.Maui.Controls.resources.dll => 0x1ff37f6ddb267c58 => 24
	i64 2329709569556905518, ; 45: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 81
	i64 2335503487726329082, ; 46: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 144
	i64 2470498323731680442, ; 47: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 74
	i64 2497223385847772520, ; 48: System.Runtime => 0x22a7eb7046413568 => 141
	i64 2547086958574651984, ; 49: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 68
	i64 2567318800469729806, ; 50: Syncfusion.Maui.PullToRefresh => 0x23a0f2d8c72e220e => 66
	i64 2602673633151553063, ; 51: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 27
	i64 2656907746661064104, ; 52: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 43
	i64 2662981627730767622, ; 53: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 2
	i64 2895129759130297543, ; 54: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 7
	i64 3017704767998173186, ; 55: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 94
	i64 3106852385031680087, ; 56: System.Runtime.Serialization.Xml => 0x2b1dc1c88b637057 => 140
	i64 3289520064315143713, ; 57: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 80
	i64 3311221304742556517, ; 58: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 125
	i64 3325875462027654285, ; 59: System.Runtime.Numerics => 0x2e27e21c8958b48d => 137
	i64 3344514922410554693, ; 60: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 96
	i64 3429672777697402584, ; 61: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 52
	i64 3494946837667399002, ; 62: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 41
	i64 3522470458906976663, ; 63: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 91
	i64 3551103847008531295, ; 64: System.Private.CoreLib.dll => 0x31480e226177735f => 154
	i64 3567343442040498961, ; 65: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 22
	i64 3571415421602489686, ; 66: System.Runtime.dll => 0x319037675df7e556 => 141
	i64 3638003163729360188, ; 67: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 42
	i64 3647754201059316852, ; 68: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 150
	i64 3655542548057982301, ; 69: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 41
	i64 3716579019761409177, ; 70: netstandard.dll => 0x3393f0ed5c8c5c99 => 153
	i64 3727469159507183293, ; 71: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 89
	i64 3869221888984012293, ; 72: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 45
	i64 3890352374528606784, ; 73: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 50
	i64 3933965368022646939, ; 74: System.Net.Requests => 0x369840a8bfadc09b => 124
	i64 3953427758811096339, ; 75: PMEGPCUSTOMERBank.dll => 0x36dd6599b91aa513 => 97
	i64 3966267475168208030, ; 76: System.Memory => 0x370b03412596249e => 121
	i64 4009997192427317104, ; 77: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 139
	i64 4050760258208440355, ; 78: en-US\Syncfusion.Maui.Buttons.resources => 0x383730fe34c8a023 => 34
	i64 4073500526318903918, ; 79: System.Private.Xml.dll => 0x3887fb25779ae26e => 130
	i64 4120493066591692148, ; 80: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 33
	i64 4135615024468428857, ; 81: Syncfusion.Maui.Popup => 0x3964a7f40d358839 => 65
	i64 4154383907710350974, ; 82: System.ComponentModel => 0x39a7562737acb67e => 107
	i64 4187479170553454871, ; 83: System.Linq.Expressions => 0x3a1cea1e912fa117 => 117
	i64 4205801962323029395, ; 84: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 106
	i64 4282138915307457788, ; 85: System.Reflection.Emit => 0x3b6d36a7ddc70cfc => 133
	i64 4356591372459378815, ; 86: vi/Microsoft.Maui.Controls.resources.dll => 0x3c75b8c562f9087f => 30
	i64 4533124835995628778, ; 87: System.Reflection.Emit.dll => 0x3ee8e505540534ea => 133
	i64 4679594760078841447, ; 88: ar/Microsoft.Maui.Controls.resources.dll => 0x40f142a407475667 => 0
	i64 4743821336939966868, ; 89: System.ComponentModel.Annotations => 0x41d5705f4239b194 => 104
	i64 4794310189461587505, ; 90: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 68
	i64 4795410492532947900, ; 91: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 91
	i64 4809057822547766521, ; 92: System.Drawing => 0x42bd349c3145ecf9 => 114
	i64 4853321196694829351, ; 93: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 136
	i64 5103417709280584325, ; 94: System.Collections.Specialized => 0x46d2fb5e161b6285 => 102
	i64 5182934613077526976, ; 95: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 102
	i64 5290786973231294105, ; 96: System.Runtime.Loader => 0x496ca6b869b72699 => 136
	i64 5332349484191854038, ; 97: Syncfusion.Maui.Core.dll => 0x4a004f9a977e2dd6 => 58
	i64 5346319026587908699, ; 98: Syncfusion.Maui.DataGrid => 0x4a31f0d423af3a5b => 60
	i64 5471532531798518949, ; 99: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 26
	i64 5521052132552059825, ; 100: Syncfusion.Maui.Inputs => 0x4c9eb7a9ab2dabb1 => 63
	i64 5522859530602327440, ; 101: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 29
	i64 5570799893513421663, ; 102: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 115
	i64 5573260873512690141, ; 103: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 142
	i64 5591791169662171124, ; 104: System.Linq.Parallel => 0x4d9a087135e137f4 => 118
	i64 5692067934154308417, ; 105: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 93
	i64 6022628403297368461, ; 106: Syncfusion.Maui.DataGrid.dll => 0x5394ac9fa0b7b98d => 60
	i64 6068057819846744445, ; 107: ro/Microsoft.Maui.Controls.resources.dll => 0x5436126fec7f197d => 23
	i64 6072574083591391795, ; 108: Syncfusion.Maui.Inputs.dll => 0x54461df484b54a33 => 63
	i64 6182294023748435638, ; 109: AsyncAwaitBestPractices => 0x55cbeba8ce8bbeb6 => 38
	i64 6200764641006662125, ; 110: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 23
	i64 6222399776351216807, ; 111: System.Text.Json.dll => 0x565a67a0ffe264a7 => 145
	i64 6225364669314151892, ; 112: en-US\Syncfusion.Maui.DataGrid.resources => 0x5664f02eefbcb5d4 => 35
	i64 6278736998281604212, ; 113: System.Private.DataContractSerialization => 0x57228e08a4ad6c74 => 127
	i64 6284145129771520194, ; 114: System.Reflection.Emit.ILGeneration => 0x5735c4b3610850c2 => 131
	i64 6357457916754632952, ; 115: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 37
	i64 6401687960814735282, ; 116: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 81
	i64 6478287442656530074, ; 117: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 11
	i64 6504860066809920875, ; 118: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 71
	i64 6548213210057960872, ; 119: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 77
	i64 6560151584539558821, ; 120: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 47
	i64 6643574370781285801, ; 121: Syncfusion.Maui.Sliders => 0x5c32b7b0e94ecda9 => 67
	i64 6743165466166707109, ; 122: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 19
	i64 6777482997383978746, ; 123: pt/Microsoft.Maui.Controls.resources.dll => 0x5e0e74e0a2525efa => 22
	i64 6784420147581266553, ; 124: en-US/Syncfusion.Maui.Buttons.resources.dll => 0x5e271a2dc795aa79 => 34
	i64 6786606130239981554, ; 125: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 112
	i64 6814185388980153342, ; 126: System.Xml.XDocument.dll => 0x5e90d98217d1abfe => 151
	i64 6876862101832370452, ; 127: System.Xml.Linq => 0x5f6f85a57d108914 => 149
	i64 6894844156784520562, ; 128: System.Numerics.Vectors => 0x5faf683aead1ad72 => 125
	i64 7083547580668757502, ; 129: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 129
	i64 7220009545223068405, ; 130: sv/Microsoft.Maui.Controls.resources.dll => 0x6432a06d99f35af5 => 26
	i64 7270811800166795866, ; 131: System.Linq => 0x64e71ccf51a90a5a => 120
	i64 7377312882064240630, ; 132: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 106
	i64 7488575175965059935, ; 133: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 149
	i64 7489048572193775167, ; 134: System.ObjectModel => 0x67ee71ff6b419e3f => 126
	i64 7526939507201682620, ; 135: Syncfusion.Maui.DataSource.dll => 0x68750f9a349c2cbc => 61
	i64 7592577537120840276, ; 136: System.Diagnostics.Process => 0x695e410af5b2aa54 => 111
	i64 7603604403193000331, ; 137: en-US\Syncfusion.Maui.Inputs.resources => 0x69856deb48ea318b => 36
	i64 7654504624184590948, ; 138: System.Net.Http => 0x6a3a4366801b8264 => 122
	i64 7708790323521193081, ; 139: ms/Microsoft.Maui.Controls.resources.dll => 0x6afb1ff4d1730479 => 17
	i64 7714652370974252055, ; 140: System.Private.CoreLib => 0x6b0ff375198b9c17 => 154
	i64 7735176074855944702, ; 141: Microsoft.CSharp => 0x6b58dda848e391fe => 98
	i64 7735352534559001595, ; 142: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 95
	i64 7769135412902976898, ; 143: Syncfusion.Maui.Popup.dll => 0x6bd1837ed1fd5d82 => 65
	i64 7836164640616011524, ; 144: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 70
	i64 8064050204834738623, ; 145: System.Collections.dll => 0x6fe942efa61731bf => 103
	i64 8083354569033831015, ; 146: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 80
	i64 8087206902342787202, ; 147: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 110
	i64 8167236081217502503, ; 148: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 155
	i64 8185542183669246576, ; 149: System.Collections => 0x7198e33f4794aa70 => 103
	i64 8246048515196606205, ; 150: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 53
	i64 8264926008854159966, ; 151: System.Diagnostics.Process.dll => 0x72b2ea6a64a3a25e => 111
	i64 8368701292315763008, ; 152: System.Security.Cryptography => 0x7423997c6fd56140 => 142
	i64 8400357532724379117, ; 153: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 88
	i64 8410671156615598628, ; 154: System.Reflection.Emit.Lightweight.dll => 0x74b8b4daf4b25224 => 132
	i64 8518412311883997971, ; 155: System.Collections.Immutable => 0x76377add7c28e313 => 100
	i64 8563666267364444763, ; 156: System.Private.Uri => 0x76d841191140ca5b => 128
	i64 8599632406834268464, ; 157: CommunityToolkit.Maui => 0x7758081c784b4930 => 39
	i64 8614108721271900878, ; 158: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x778b763e14018ace => 21
	i64 8626175481042262068, ; 159: Java.Interop => 0x77b654e585b55834 => 155
	i64 8638972117149407195, ; 160: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 98
	i64 8639588376636138208, ; 161: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 87
	i64 8677882282824630478, ; 162: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 21
	i64 8725526185868997716, ; 163: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 110
	i64 8941376889969657626, ; 164: System.Xml.XDocument => 0x7c1626e87187471a => 151
	i64 9045785047181495996, ; 165: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 31
	i64 9312692141327339315, ; 166: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 93
	i64 9324707631942237306, ; 167: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 69
	i64 9659729154652888475, ; 168: System.Text.RegularExpressions => 0x860e407c9991dd9b => 146
	i64 9678050649315576968, ; 169: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 74
	i64 9702891218465930390, ; 170: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 101
	i64 9808709177481450983, ; 171: Mono.Android.dll => 0x881f890734e555e7 => 157
	i64 9933555792566666578, ; 172: System.Linq.Queryable.dll => 0x89db145cf475c552 => 119
	i64 9956195530459977388, ; 173: Microsoft.Maui => 0x8a2b8315b36616ac => 51
	i64 9991543690424095600, ; 174: es/Microsoft.Maui.Controls.resources.dll => 0x8aa9180c89861370 => 6
	i64 10038780035334861115, ; 175: System.Net.Http.dll => 0x8b50e941206af13b => 122
	i64 10051358222726253779, ; 176: System.Private.Xml => 0x8b7d990c97ccccd3 => 130
	i64 10065192478696882816, ; 177: Syncfusion.Maui.PullToRefresh.dll => 0x8baebf3b50a94280 => 66
	i64 10092835686693276772, ; 178: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 49
	i64 10143853363526200146, ; 179: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 3
	i64 10172042533944518731, ; 180: Syncfusion.Maui.GridCommon.dll => 0x8d2a5aca73ed684b => 62
	i64 10229024438826829339, ; 181: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 77
	i64 10245369515835430794, ; 182: System.Reflection.Emit.Lightweight => 0x8e2edd4ad7fc978a => 132
	i64 10364469296367737616, ; 183: System.Reflection.Emit.ILGeneration.dll => 0x8fd5fde967711b10 => 131
	i64 10406448008575299332, ; 184: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 96
	i64 10430153318873392755, ; 185: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 75
	i64 10506226065143327199, ; 186: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 1
	i64 10512690409504421330, ; 187: Syncfusion.Maui.GridCommon => 0x91e4943a942ab5d2 => 62
	i64 10785150219063592792, ; 188: System.Net.Primitives => 0x95ac8cfb68830758 => 123
	i64 10822644899632537592, ; 189: System.Linq.Queryable => 0x9631c23204ca5ff8 => 119
	i64 10880838204485145808, ; 190: CommunityToolkit.Maui.dll => 0x970080b2a4d614d0 => 39
	i64 11002576679268595294, ; 191: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 46
	i64 11009005086950030778, ; 192: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 51
	i64 11103970607964515343, ; 193: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 12
	i64 11162124722117608902, ; 194: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 92
	i64 11220793807500858938, ; 195: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 15
	i64 11226290749488709958, ; 196: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 47
	i64 11340910727871153756, ; 197: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 76
	i64 11485890710487134646, ; 198: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 135
	i64 11518296021396496455, ; 199: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 13
	i64 11529969570048099689, ; 200: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 92
	i64 11530571088791430846, ; 201: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 45
	i64 11597940890313164233, ; 202: netstandard => 0xa0f429ca8d1805c9 => 153
	i64 11705530742807338875, ; 203: he/Microsoft.Maui.Controls.resources.dll => 0xa272663128721f7b => 9
	i64 11707554492040141440, ; 204: System.Linq.Parallel.dll => 0xa27996c7fe94da80 => 118
	i64 11921434729483622790, ; 205: Mopups.dll => 0xa57171b957e05986 => 54
	i64 12145679461940342714, ; 206: System.Text.Json => 0xa88e1f1ebcb62fba => 145
	i64 12201331334810686224, ; 207: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 139
	i64 12245746946636392273, ; 208: Syncfusion.Maui.Sliders.dll => 0xa9f1a1f79b962751 => 67
	i64 12269460666702402136, ; 209: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 100
	i64 12321291134648533416, ; 210: Mopups => 0xaafe050186e541a8 => 54
	i64 12341818387765915815, ; 211: CommunityToolkit.Maui.Core.dll => 0xab46f26f152bf0a7 => 40
	i64 12451044538927396471, ; 212: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 79
	i64 12466513435562512481, ; 213: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 84
	i64 12475113361194491050, ; 214: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 37
	i64 12517810545449516888, ; 215: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 112
	i64 12538491095302438457, ; 216: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 72
	i64 12550732019250633519, ; 217: System.IO.Compression => 0xae2d28465e8e1b2f => 116
	i64 12681088699309157496, ; 218: it/Microsoft.Maui.Controls.resources.dll => 0xaffc46fc178aec78 => 14
	i64 12700543734426720211, ; 219: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 73
	i64 12708922737231849740, ; 220: System.Text.Encoding.Extensions => 0xb05f29e50e96e90c => 143
	i64 12717050818822477433, ; 221: System.Runtime.Serialization.Xml.dll => 0xb07c0a5786811679 => 140
	i64 12823819093633476069, ; 222: th/Microsoft.Maui.Controls.resources.dll => 0xb1f75b85abe525e5 => 27
	i64 12843321153144804894, ; 223: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 48
	i64 13068258254871114833, ; 224: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 138
	i64 13221551921002590604, ; 225: ca/Microsoft.Maui.Controls.resources.dll => 0xb77c636bdebe318c => 1
	i64 13222659110913276082, ; 226: ja/Microsoft.Maui.Controls.resources.dll => 0xb78052679c1178b2 => 15
	i64 13343850469010654401, ; 227: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 156
	i64 13381594904270902445, ; 228: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 9
	i64 13426597916859742023, ; 229: PMEGPCUSTOMERBank => 0xba54dbab106cb747 => 97
	i64 13463706743370286408, ; 230: System.Private.DataContractSerialization.dll => 0xbad8b1f3069e0548 => 127
	i64 13465488254036897740, ; 231: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 95
	i64 13467053111158216594, ; 232: uk/Microsoft.Maui.Controls.resources.dll => 0xbae49573fde79792 => 29
	i64 13492260750531519258, ; 233: Syncfusion.Maui.ListView.dll => 0xbb3e23aae460631a => 64
	i64 13540124433173649601, ; 234: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 30
	i64 13545416393490209236, ; 235: id/Microsoft.Maui.Controls.resources.dll => 0xbbfafc7174bc99d4 => 13
	i64 13572454107664307259, ; 236: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 89
	i64 13717397318615465333, ; 237: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 105
	i64 13755568601956062840, ; 238: fr/Microsoft.Maui.Controls.resources.dll => 0xbee598c36b1b9678 => 8
	i64 13814445057219246765, ; 239: hr/Microsoft.Maui.Controls.resources.dll => 0xbfb6c49664b43aad => 11
	i64 13881769479078963060, ; 240: System.Console.dll => 0xc0a5f3cade5c6774 => 108
	i64 13959074834287824816, ; 241: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 79
	i64 13970307180132182141, ; 242: Syncfusion.Licensing => 0xc1e0805ccade287d => 56
	i64 14100563506285742564, ; 243: da/Microsoft.Maui.Controls.resources.dll => 0xc3af43cd0cff89e4 => 3
	i64 14124974489674258913, ; 244: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 72
	i64 14125464355221830302, ; 245: System.Threading.dll => 0xc407bafdbc707a9e => 148
	i64 14254574811015963973, ; 246: System.Text.Encoding.Extensions.dll => 0xc5d26c4442d66545 => 143
	i64 14353329275190349375, ; 247: Syncfusion.Maui.ListView => 0xc73144edb7ef8e3f => 64
	i64 14390169238844270433, ; 248: AsyncAwaitBestPractices.dll => 0xc7b426ae2b10e761 => 38
	i64 14461014870687870182, ; 249: System.Net.Requests.dll => 0xc8afd8683afdece6 => 124
	i64 14464374589798375073, ; 250: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 24
	i64 14522721392235705434, ; 251: el/Microsoft.Maui.Controls.resources.dll => 0xc98b12295c2cf45a => 5
	i64 14538127318538747197, ; 252: Syncfusion.Licensing.dll => 0xc9c1cdc518e77d3d => 56
	i64 14551742072151931844, ; 253: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 144
	i64 14556034074661724008, ; 254: CommunityToolkit.Maui.Core => 0xca016bdea6b19f68 => 40
	i64 14622043554576106986, ; 255: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 138
	i64 14669215534098758659, ; 256: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 43
	i64 14705122255218365489, ; 257: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 16
	i64 14744092281598614090, ; 258: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 32
	i64 14852515768018889994, ; 259: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 76
	i64 14892012299694389861, ; 260: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xceab0e490a083a65 => 33
	i64 14904040806490515477, ; 261: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 0
	i64 14954917835170835695, ; 262: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 44
	i64 14987728460634540364, ; 263: System.IO.Compression.dll => 0xcfff1ba06622494c => 116
	i64 15076659072870671916, ; 264: System.ObjectModel.dll => 0xd13b0d8c1620662c => 126
	i64 15111608613780139878, ; 265: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 17
	i64 15115185479366240210, ; 266: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 115
	i64 15133485256822086103, ; 267: System.Linq.dll => 0xd204f0a9127dd9d7 => 120
	i64 15227001540531775957, ; 268: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 42
	i64 15370334346939861994, ; 269: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 75
	i64 15391712275433856905, ; 270: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 44
	i64 15527772828719725935, ; 271: System.Console => 0xd77dbb1e38cd3d6f => 108
	i64 15536481058354060254, ; 272: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 4
	i64 15582737692548360875, ; 273: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 83
	i64 15609085926864131306, ; 274: System.dll => 0xd89e9cf3334914ea => 152
	i64 15661133872274321916, ; 275: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 150
	i64 15664356999916475676, ; 276: de/Microsoft.Maui.Controls.resources.dll => 0xd962f9b2b6ecd51c => 4
	i64 15743187114543869802, ; 277: hu/Microsoft.Maui.Controls.resources.dll => 0xda7b09450ae4ef6a => 12
	i64 15745825835632158716, ; 278: Syncfusion.Maui.Core => 0xda84692c2c05e7fc => 58
	i64 15783653065526199428, ; 279: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 5
	i64 16154507427712707110, ; 280: System => 0xe03056ea4e39aa26 => 152
	i64 16288847719894691167, ; 281: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 18
	i64 16321164108206115771, ; 282: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 46
	i64 16649148416072044166, ; 283: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 53
	i64 16677317093839702854, ; 284: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 88
	i64 16856067890322379635, ; 285: System.Data.Common.dll => 0xe9ecc87060889373 => 109
	i64 16890310621557459193, ; 286: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 146
	i64 16942731696432749159, ; 287: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 25
	i64 16998075588627545693, ; 288: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 86
	i64 17008137082415910100, ; 289: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 101
	i64 17031351772568316411, ; 290: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 85
	i64 17062143951396181894, ; 291: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 105
	i64 17089008752050867324, ; 292: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xed285aeb25888c7c => 32
	i64 17102494345910816168, ; 293: Syncfusion.Maui.Buttons => 0xed5843fea5240da8 => 57
	i64 17187273293601214786, ; 294: System.ComponentModel.Annotations.dll => 0xee8575ff9aa89142 => 104
	i64 17230721278011714856, ; 295: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 129
	i64 17260702271250283638, ; 296: System.Data.Common => 0xef8a5543bba6bc76 => 109
	i64 17342750010158924305, ; 297: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 10
	i64 17438153253682247751, ; 298: sk/Microsoft.Maui.Controls.resources.dll => 0xf200c3fe308d7847 => 25
	i64 17514990004910432069, ; 299: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 8
	i64 17623389608345532001, ; 300: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 20
	i64 17702523067201099846, ; 301: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xf5abfef008ae1846 => 31
	i64 17704177640604968747, ; 302: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 84
	i64 17710060891934109755, ; 303: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 82
	i64 17712670374920797664, ; 304: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 135
	i64 17777860260071588075, ; 305: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 137
	i64 18025913125965088385, ; 306: System.Threading => 0xfa28e87b91334681 => 148
	i64 18027900539557172254, ; 307: Syncfusion.Maui.Data => 0xfa2ff8065a60d41e => 59
	i64 18099568558057551825, ; 308: nl/Microsoft.Maui.Controls.resources.dll => 0xfb2e95b53ad977d1 => 19
	i64 18121036031235206392, ; 309: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 85
	i64 18150477613000255151, ; 310: en-US/Syncfusion.Maui.Inputs.resources.dll => 0xfbe37339428f66af => 36
	i64 18164061295166068260, ; 311: Syncfusion.Maui.DataSource => 0xfc13b582b8cb9624 => 61
	i64 18245806341561545090, ; 312: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 99
	i64 18254913412602728065, ; 313: en-US/Syncfusion.Maui.DataGrid.resources.dll => 0xfd567b07b3b30e81 => 35
	i64 18305135509493619199, ; 314: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 87
	i64 18324163916253801303 ; 315: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 14
], align 16

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [316 x i32] [
	i32 48, ; 0
	i32 157, ; 1
	i32 52, ; 2
	i32 117, ; 3
	i32 73, ; 4
	i32 90, ; 5
	i32 59, ; 6
	i32 7, ; 7
	i32 134, ; 8
	i32 147, ; 9
	i32 107, ; 10
	i32 10, ; 11
	i32 78, ; 12
	i32 134, ; 13
	i32 94, ; 14
	i32 18, ; 15
	i32 57, ; 16
	i32 114, ; 17
	i32 86, ; 18
	i32 123, ; 19
	i32 49, ; 20
	i32 156, ; 21
	i32 147, ; 22
	i32 16, ; 23
	i32 70, ; 24
	i32 83, ; 25
	i32 55, ; 26
	i32 121, ; 27
	i32 128, ; 28
	i32 69, ; 29
	i32 6, ; 30
	i32 90, ; 31
	i32 113, ; 32
	i32 28, ; 33
	i32 50, ; 34
	i32 28, ; 35
	i32 82, ; 36
	i32 2, ; 37
	i32 20, ; 38
	i32 113, ; 39
	i32 55, ; 40
	i32 71, ; 41
	i32 78, ; 42
	i32 99, ; 43
	i32 24, ; 44
	i32 81, ; 45
	i32 144, ; 46
	i32 74, ; 47
	i32 141, ; 48
	i32 68, ; 49
	i32 66, ; 50
	i32 27, ; 51
	i32 43, ; 52
	i32 2, ; 53
	i32 7, ; 54
	i32 94, ; 55
	i32 140, ; 56
	i32 80, ; 57
	i32 125, ; 58
	i32 137, ; 59
	i32 96, ; 60
	i32 52, ; 61
	i32 41, ; 62
	i32 91, ; 63
	i32 154, ; 64
	i32 22, ; 65
	i32 141, ; 66
	i32 42, ; 67
	i32 150, ; 68
	i32 41, ; 69
	i32 153, ; 70
	i32 89, ; 71
	i32 45, ; 72
	i32 50, ; 73
	i32 124, ; 74
	i32 97, ; 75
	i32 121, ; 76
	i32 139, ; 77
	i32 34, ; 78
	i32 130, ; 79
	i32 33, ; 80
	i32 65, ; 81
	i32 107, ; 82
	i32 117, ; 83
	i32 106, ; 84
	i32 133, ; 85
	i32 30, ; 86
	i32 133, ; 87
	i32 0, ; 88
	i32 104, ; 89
	i32 68, ; 90
	i32 91, ; 91
	i32 114, ; 92
	i32 136, ; 93
	i32 102, ; 94
	i32 102, ; 95
	i32 136, ; 96
	i32 58, ; 97
	i32 60, ; 98
	i32 26, ; 99
	i32 63, ; 100
	i32 29, ; 101
	i32 115, ; 102
	i32 142, ; 103
	i32 118, ; 104
	i32 93, ; 105
	i32 60, ; 106
	i32 23, ; 107
	i32 63, ; 108
	i32 38, ; 109
	i32 23, ; 110
	i32 145, ; 111
	i32 35, ; 112
	i32 127, ; 113
	i32 131, ; 114
	i32 37, ; 115
	i32 81, ; 116
	i32 11, ; 117
	i32 71, ; 118
	i32 77, ; 119
	i32 47, ; 120
	i32 67, ; 121
	i32 19, ; 122
	i32 22, ; 123
	i32 34, ; 124
	i32 112, ; 125
	i32 151, ; 126
	i32 149, ; 127
	i32 125, ; 128
	i32 129, ; 129
	i32 26, ; 130
	i32 120, ; 131
	i32 106, ; 132
	i32 149, ; 133
	i32 126, ; 134
	i32 61, ; 135
	i32 111, ; 136
	i32 36, ; 137
	i32 122, ; 138
	i32 17, ; 139
	i32 154, ; 140
	i32 98, ; 141
	i32 95, ; 142
	i32 65, ; 143
	i32 70, ; 144
	i32 103, ; 145
	i32 80, ; 146
	i32 110, ; 147
	i32 155, ; 148
	i32 103, ; 149
	i32 53, ; 150
	i32 111, ; 151
	i32 142, ; 152
	i32 88, ; 153
	i32 132, ; 154
	i32 100, ; 155
	i32 128, ; 156
	i32 39, ; 157
	i32 21, ; 158
	i32 155, ; 159
	i32 98, ; 160
	i32 87, ; 161
	i32 21, ; 162
	i32 110, ; 163
	i32 151, ; 164
	i32 31, ; 165
	i32 93, ; 166
	i32 69, ; 167
	i32 146, ; 168
	i32 74, ; 169
	i32 101, ; 170
	i32 157, ; 171
	i32 119, ; 172
	i32 51, ; 173
	i32 6, ; 174
	i32 122, ; 175
	i32 130, ; 176
	i32 66, ; 177
	i32 49, ; 178
	i32 3, ; 179
	i32 62, ; 180
	i32 77, ; 181
	i32 132, ; 182
	i32 131, ; 183
	i32 96, ; 184
	i32 75, ; 185
	i32 1, ; 186
	i32 62, ; 187
	i32 123, ; 188
	i32 119, ; 189
	i32 39, ; 190
	i32 46, ; 191
	i32 51, ; 192
	i32 12, ; 193
	i32 92, ; 194
	i32 15, ; 195
	i32 47, ; 196
	i32 76, ; 197
	i32 135, ; 198
	i32 13, ; 199
	i32 92, ; 200
	i32 45, ; 201
	i32 153, ; 202
	i32 9, ; 203
	i32 118, ; 204
	i32 54, ; 205
	i32 145, ; 206
	i32 139, ; 207
	i32 67, ; 208
	i32 100, ; 209
	i32 54, ; 210
	i32 40, ; 211
	i32 79, ; 212
	i32 84, ; 213
	i32 37, ; 214
	i32 112, ; 215
	i32 72, ; 216
	i32 116, ; 217
	i32 14, ; 218
	i32 73, ; 219
	i32 143, ; 220
	i32 140, ; 221
	i32 27, ; 222
	i32 48, ; 223
	i32 138, ; 224
	i32 1, ; 225
	i32 15, ; 226
	i32 156, ; 227
	i32 9, ; 228
	i32 97, ; 229
	i32 127, ; 230
	i32 95, ; 231
	i32 29, ; 232
	i32 64, ; 233
	i32 30, ; 234
	i32 13, ; 235
	i32 89, ; 236
	i32 105, ; 237
	i32 8, ; 238
	i32 11, ; 239
	i32 108, ; 240
	i32 79, ; 241
	i32 56, ; 242
	i32 3, ; 243
	i32 72, ; 244
	i32 148, ; 245
	i32 143, ; 246
	i32 64, ; 247
	i32 38, ; 248
	i32 124, ; 249
	i32 24, ; 250
	i32 5, ; 251
	i32 56, ; 252
	i32 144, ; 253
	i32 40, ; 254
	i32 138, ; 255
	i32 43, ; 256
	i32 16, ; 257
	i32 32, ; 258
	i32 76, ; 259
	i32 33, ; 260
	i32 0, ; 261
	i32 44, ; 262
	i32 116, ; 263
	i32 126, ; 264
	i32 17, ; 265
	i32 115, ; 266
	i32 120, ; 267
	i32 42, ; 268
	i32 75, ; 269
	i32 44, ; 270
	i32 108, ; 271
	i32 4, ; 272
	i32 83, ; 273
	i32 152, ; 274
	i32 150, ; 275
	i32 4, ; 276
	i32 12, ; 277
	i32 58, ; 278
	i32 5, ; 279
	i32 152, ; 280
	i32 18, ; 281
	i32 46, ; 282
	i32 53, ; 283
	i32 88, ; 284
	i32 109, ; 285
	i32 146, ; 286
	i32 25, ; 287
	i32 86, ; 288
	i32 101, ; 289
	i32 85, ; 290
	i32 105, ; 291
	i32 32, ; 292
	i32 57, ; 293
	i32 104, ; 294
	i32 129, ; 295
	i32 109, ; 296
	i32 10, ; 297
	i32 25, ; 298
	i32 8, ; 299
	i32 20, ; 300
	i32 31, ; 301
	i32 84, ; 302
	i32 82, ; 303
	i32 135, ; 304
	i32 137, ; 305
	i32 148, ; 306
	i32 59, ; 307
	i32 19, ; 308
	i32 85, ; 309
	i32 36, ; 310
	i32 61, ; 311
	i32 99, ; 312
	i32 35, ; 313
	i32 87, ; 314
	i32 14 ; 315
], align 16

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

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
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 16

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ 82d8938cf80f6d5fa6c28529ddfbdb753d805ab4"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
