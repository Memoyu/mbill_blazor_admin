"use strict";

var _interopRequireWildcard = require("@babel/runtime/helpers/interopRequireWildcard");

var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault");

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports["default"] = exports.icons = void 0;

var _extends2 = _interopRequireDefault(require("@babel/runtime/helpers/extends"));

var React = _interopRequireWildcard(require("react"));

var _rcImage = _interopRequireDefault(require("rc-image"));

var _RotateLeftOutlined = _interopRequireDefault(require("@ant-design/icons/RotateLeftOutlined"));

var _RotateRightOutlined = _interopRequireDefault(require("@ant-design/icons/RotateRightOutlined"));

var _ZoomInOutlined = _interopRequireDefault(require("@ant-design/icons/ZoomInOutlined"));

var _ZoomOutOutlined = _interopRequireDefault(require("@ant-design/icons/ZoomOutOutlined"));

var _CloseOutlined = _interopRequireDefault(require("@ant-design/icons/CloseOutlined"));

var _LeftOutlined = _interopRequireDefault(require("@ant-design/icons/LeftOutlined"));

var _RightOutlined = _interopRequireDefault(require("@ant-design/icons/RightOutlined"));

var _configProvider = require("../config-provider");

var __rest = void 0 && (void 0).__rest || function (s, e) {
  var t = {};

  for (var p in s) {
    if (Object.prototype.hasOwnProperty.call(s, p) && e.indexOf(p) < 0) t[p] = s[p];
  }

  if (s != null && typeof Object.getOwnPropertySymbols === "function") for (var i = 0, p = Object.getOwnPropertySymbols(s); i < p.length; i++) {
    if (e.indexOf(p[i]) < 0 && Object.prototype.propertyIsEnumerable.call(s, p[i])) t[p[i]] = s[p[i]];
  }
  return t;
};

var icons = {
  rotateLeft: /*#__PURE__*/React.createElement(_RotateLeftOutlined["default"], null),
  rotateRight: /*#__PURE__*/React.createElement(_RotateRightOutlined["default"], null),
  zoomIn: /*#__PURE__*/React.createElement(_ZoomInOutlined["default"], null),
  zoomOut: /*#__PURE__*/React.createElement(_ZoomOutOutlined["default"], null),
  close: /*#__PURE__*/React.createElement(_CloseOutlined["default"], null),
  left: /*#__PURE__*/React.createElement(_LeftOutlined["default"], null),
  right: /*#__PURE__*/React.createElement(_RightOutlined["default"], null)
};
exports.icons = icons;

var InternalPreviewGroup = function InternalPreviewGroup(_a) {
  var customizePrefixCls = _a.previewPrefixCls,
      props = __rest(_a, ["previewPrefixCls"]);

  var _React$useContext = React.useContext(_configProvider.ConfigContext),
      getPrefixCls = _React$useContext.getPrefixCls;

  var prefixCls = getPrefixCls('image-preview', customizePrefixCls);
  return /*#__PURE__*/React.createElement(_rcImage["default"].PreviewGroup, (0, _extends2["default"])({
    previewPrefixCls: prefixCls,
    icons: icons
  }, props));
};

var _default = InternalPreviewGroup;
exports["default"] = _default;