/**
 * タッチできるデバイスかどうかを確認します
 * @returns {Boolean} 真ならタッチ可能
 */
function CheckTouchDevice() {
  var touchEvent = window.ontouchstart;
  let touchPoints = navigator.maxTouchPoints;

  // 端末がタッチに対応している
  if (touchEvent !== undefined && touchPoints > 0) {
    return true;
  }

  return false;
}

/**
 * デバイス種別をUnity側で確認できる文字列にして返します
 * @returns {string} デバイス種別
 * @see https://docs.unity3d.com/ja/2022.3/Manual/webgl-interactingwithbrowserscripting.html
 */
function GetDeviceType() {
  var returnStr;
  var userAgent = window.navigator.userAgent.toLocaleLowerCase();

  if (userAgent.indexOf("iphone") != -1) {
    returnStr = "iPhone";
  } else if (
    userAgent.indexOf("ipad") != -1 ||
    (userAgent.indexOf("macintosh") > -1 && "ontouchend" in document)
  ) {
    returnStr = "iPad";
  } else if (userAgent.indexOf("android") != -1) {
    if (userAgent.indexOf("mobile") != -1) {
      returnStr = "Android Phone";
    } else {
      returnStr = "Android Tablet";
    }
  } else {
    returnStr = "PC";
  }

  // UTF-8形式にして返す
  var bufferSize = lengthBytesUTF8(returnStr) + 1;
  var buffer = _malloc(bufferSize);
  stringToUTF8(returnStr, buffer, bufferSize);
  return buffer;
}

const plugins = {};
plugins[CheckTouchDevice.name] = CheckTouchDevice;
plugins[GetDeviceType.name] = GetDeviceType;

// Unity側へ反映
mergeInto(LibraryManager.library, plugins);
