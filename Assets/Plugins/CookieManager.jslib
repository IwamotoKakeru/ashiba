function SetClearTimes(clearTimes) {
  document.cookie = "clear_times=" + clearTimes + ";max-age=31536000";
  console.log("Set clearTimes = %d ", clearTimes);
}

// TODO: 現在の実装だとclearTimes以外の保存したいデータに対応できないので修正
function GetClearTimes() {
  var clearTimes;
  try {
    clearTimes = parseInt(document.cookie.split("=")[1]);
    console.log("clearTimes = %d ", clearTimes);
  } catch {
    console.log("Unable Get clearTimes", clearTimes);
  }
  return clearTimes;
}

const cookiePlugins = {};
cookiePlugins[SetClearTimes.name] = SetClearTimes;
cookiePlugins[GetClearTimes.name] = GetClearTimes;

// Unity側へ反映
mergeInto(LibraryManager.library, cookiePlugins);
