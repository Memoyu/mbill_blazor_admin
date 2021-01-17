import { Context } from 'react';
export interface RowContextState {
    gutter?: [number, number];
    wrap?: boolean;
}
declare const RowContext: Context<RowContextState>;
export default RowContext;
