function SetClearTimes(clearTimes) {
  document.cookie = "clear_times=" + score;
}

// TODO: 現在の実装だとclearTimes以外の保存したいデータに対応できないので修正
function GetClearTimes() {
  return parseInt(document.cookie.split("=")[1]);
}

const cookiePlugins = {};
cookiePlugins[SetClearTimes.name] = SetClearTimes;
cookiePlugins[GetClearTimes.name] = GetClearTimes;

// Unity側へ反映
mergeInto(LibraryManager.library, cookiePlugins);
