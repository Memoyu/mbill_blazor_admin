export default function useFreshState<T>(defaultValue: T, propValue?: T): [(displayValue?: boolean) => T, (newValue: T) => void];
