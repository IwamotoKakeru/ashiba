/**
 * タッチできるデバイスかどうかをチェックします
 * @returns {Boolean} 真ならタッチ可能
 */

mergeInto(LibraryManager.library, {
  CheckTouchDevice: function () {
    var touchEvent = window.ontouchstart;
    let touchPoints = navigator.maxTouchPoints;

    var userAgent = window.navigator.userAgent.toLocaleLowerCase();

    // 端末がタッチに対応している
    if (touchEvent !== undefined && touchPoints > 0) {
      return true;
    }

    // iPhone
    if (userAgent.indexOf("iphone") != -1) {
      return true;
    }

    // iPad
    if (userAgent.indexOf("ipad") != -1) {
      return true;
    }

    // android端末
    if (userAgent.indexOf("android") != -1) {
      return true;
    }

    return false;
  },
});
