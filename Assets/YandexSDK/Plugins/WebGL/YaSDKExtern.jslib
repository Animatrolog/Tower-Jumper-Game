mergeInto(LibraryManager.library, 
{

	ShowFullscreenAd: function() 
	{
		showFullScreenAdv();
	},

	ShowRewardedAd: function(placement) 
	{
		showRewardedAdv(placement);
		return placement;
	},

	OpenRateUs: function(placement)
	{
		openRateUs();
	},

	Authenticate: function()
	{
		auth();
	},

	SetPlayerData: function(dataStr)
	{
		setPlayerData(UTF8ToString(dataStr));
	},

	GetPlayerData: function()
	{
		getPlayerData();
	},

	GetPlayerLang: function () 
	{
		var lang = sdk.environment.i18n.lang;
		var bufferSize = lengthBytesUTF8(lang) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(lang, buffer, bufferSize);
		return buffer;
	}

});