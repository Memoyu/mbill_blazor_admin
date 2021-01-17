import OriginModal from './Modal';
import { ModalStaticFunctions, globalConfig } from './confirm';
export { ActionButtonProps } from './ActionButton';
export { ModalProps, ModalFuncProps } from './Modal';
declare type ModalType = typeof OriginModal & ModalStaticFunctions & {
    destroyAll: () => void;
    config: typeof globalConfig;
};
declare const Modal: ModalType;
export default Modal;
