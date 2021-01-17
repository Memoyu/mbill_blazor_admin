import { ModalFuncProps } from './Modal';
declare type ConfigUpdate = ModalFuncProps | ((prevConfig: ModalFuncProps) => ModalFuncProps);
export declare type ModalFunc = (props: ModalFuncProps) => {
    destroy: () => void;
    update: (configUpdate: ConfigUpdate) => void;
};
export interface ModalStaticFunctions {
    info: ModalFunc;
    success: ModalFunc;
    error: ModalFunc;
    warn: ModalFunc;
    warning: ModalFunc;
    confirm: ModalFunc;
}
export default function confirm(config: ModalFuncProps): {
    destroy: (...args: any[]) => void;
    update: (configUpdate: ConfigUpdate) => void;
};
export declare function withWarn(props: ModalFuncProps): ModalFuncProps;
export declare function withInfo(props: ModalFuncProps): ModalFuncProps;
export declare function withSuccess(props: ModalFuncProps): ModalFuncProps;
export declare function withError(props: ModalFuncProps): ModalFuncProps;
export declare function withConfirm(props: ModalFuncProps): ModalFuncProps;
export declare function globalConfig({ rootPrefixCls }: {
    rootPrefixCls?: string;
}): void;
export {};
