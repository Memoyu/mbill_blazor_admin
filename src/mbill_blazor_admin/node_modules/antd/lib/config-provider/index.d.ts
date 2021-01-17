import * as React from 'react';
import { ValidateMessages } from 'rc-field-form/lib/interface';
import { RenderEmptyHandler } from './renderEmpty';
import { Locale } from '../locale-provider';
import { ConfigConsumer, ConfigContext, CSPConfig, DirectionType, ConfigConsumerProps } from './context';
import { SizeType } from './SizeContext';
import { RequiredMark } from '../form/Form';
export { RenderEmptyHandler, ConfigContext, ConfigConsumer, CSPConfig, DirectionType, ConfigConsumerProps, };
export declare const configConsumerProps: string[];
export interface ConfigProviderProps {
    getTargetContainer?: () => HTMLElement;
    getPopupContainer?: (triggerNode: HTMLElement) => HTMLElement;
    prefixCls?: string;
    children?: React.ReactNode;
    renderEmpty?: RenderEmptyHandler;
    csp?: CSPConfig;
    autoInsertSpaceInButton?: boolean;
    form?: {
        validateMessages?: ValidateMessages;
        requiredMark?: RequiredMark;
    };
    input?: {
        autoComplete?: string;
    };
    locale?: Locale;
    pageHeader?: {
        ghost: boolean;
    };
    componentSize?: SizeType;
    direction?: DirectionType;
    space?: {
        size?: SizeType | number;
    };
    virtual?: boolean;
    dropdownMatchSelectWidth?: boolean;
}
declare const ConfigProvider: React.FC<ConfigProviderProps> & {
    ConfigContext: typeof ConfigContext;
};
export default ConfigProvider;
