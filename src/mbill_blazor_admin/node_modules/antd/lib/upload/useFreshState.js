"use strict";

var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault");

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports["default"] = useFreshState;

var _react = require("react");

var _raf = _interopRequireDefault(require("rc-util/lib/raf"));

var _useForceUpdate = _interopRequireDefault(require("../_util/hooks/useForceUpdate"));

// Note. Only for upload usage. Do not export to global util hooks
function useFreshState(defaultValue, propValue) {
  var valueRef = (0, _react.useRef)(defaultValue);
  var forceUpdate = (0, _useForceUpdate["default"])();
  var rafRef = (0, _react.useRef)(); // Set value

  function setValue(newValue) {
    valueRef.current = newValue;
    forceUpdate();
  }

  function cleanUp() {
    _raf["default"].cancel(rafRef.current);
  }

  function rafSyncValue(newValue) {
    cleanUp();
    rafRef.current = (0, _raf["default"])(function () {
      setValue(newValue);
    });
  } // Get value


  function getValue() {
    var displayValue = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : false;

    if (displayValue) {
      return propValue || valueRef.current;
    }

    return valueRef.current;
  } // Effect will always update in a next frame to avoid sync state overwrite current processing state


  (0, _react.useEffect)(function () {
    if (propValue) {
      rafSyncValue(propValue);
    }
  }, [propValue]); // Clean up

  (0, _react.useEffect)(function () {
    return function () {
      cleanUp();
    };
  }, []);
  return [getValue, setValue];
}