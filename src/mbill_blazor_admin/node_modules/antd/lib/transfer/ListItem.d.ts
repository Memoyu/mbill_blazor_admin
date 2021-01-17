import * as React from 'react';
declare type ListItemProps<RecordType> = {
    renderedText?: string | number;
    renderedEl: React.ReactNode;
    disabled?: boolean;
    checked?: boolean;
    prefixCls: string;
    onClick: (item: RecordType) => void;
    onRemove?: (item: RecordType) => void;
    item: RecordType;
    showRemove?: boolean;
};
declare const _default: React.MemoExoticComponent<(<RecordType extends import(".").KeyWise<import(".").TransferItem>>(props: ListItemProps<RecordType>) => JSX.Element)>;
export default _default;
