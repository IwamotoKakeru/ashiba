function SetClearTimes(clearTimes) {
  document.cookie = "clear_times=" + clearTimes + ";max-age=31536000";
  console.log("Set clearTimes = %d ", clearTimes);
}

function GetClearTimes() {
  var clearTimes = 0;
  var arr = new Array();

  try {
    if (document.cookie != "") {
      var tmp = document.cookie.split("; ");
      for (var i = 0; i < tmp.length; i++) {
        var data = tmp[i].split("=");
        arr[data[0]] = decodeURIComponent(data[1]);
      }
    }
    clearTimes = parseInt(arr["clear_times"]);
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
