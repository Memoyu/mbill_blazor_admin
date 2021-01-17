import { useRef, useEffect } from 'react';
import raf from "rc-util/es/raf";
import useForceUpdate from '../_util/hooks/useForceUpdate'; // Note. Only for upload usage. Do not export to global util hooks

export default function useFreshState(defaultValue, propValue) {
  var valueRef = useRef(defaultValue);
  var forceUpdate = useForceUpdate();
  var rafRef = useRef(); // Set value

  function setValue(newValue) {
    valueRef.current = newValue;
    forceUpdate();
  }

  function cleanUp() {
    raf.cancel(rafRef.current);
  }

  function rafSyncValue(newValue) {
    cleanUp();
    rafRef.current = raf(function () {
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


  useEffect(function () {
    if (propValue) {
      rafSyncValue(propValue);
    }
  }, [propValue]); // Clean up

  useEffect(function () {
    return function () {
      cleanUp();
    };
  }, []);
  return [getValue, setValue];
}