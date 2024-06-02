function SetClearTimes(clearTimes) {
  document.cookie = "clear_times=" + clearTimes + ";max-age=31536000";
  console.log("Set clearTimes = %d ", clearTimes);
}

function GetCookieArray() {
  var arr = new Array();
  if (document.cookie != "") {
    var tmp = document.cookie.split("; ");
    for (var i = 0; i < tmp.length; i++) {
      var data = tmp[i].split("=");
      arr[data[0]] = decodeURIComponent(data[1]);
    }
  }
  return arr;
}

// TODO: 現在の実装だとclearTimes以外の保存したいデータに対応できないので修正
function GetClearTimes() {
  var clearTimes;
  try {
    clearTimes = parseInt(GetCookieArray()["clear_times"]);
    console.log("clearTimes = %d ", clearTimes);
  } catch {
    console.log("Unable Get clearTimes", clearTimes);
  }
  return clearTimes;
}

// 使用したい関数をオブジェクトとして配置
const cookiePlugins = {};
cookiePlugins[SetClearTimes.name] = SetClearTimes;
cookiePlugins[GetClearTimes.name] = GetClearTimes;

// Unity側へ反映
mergeInto(LibraryManager.library, cookiePlugins);
