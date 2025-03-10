import React from 'react';

import {HexColorPicker} from "react-colorful";

import {FormComponentProps} from '@kentico/xperience-admin-base';
import {FormItemWrapper} from '@kentico/xperience-admin-components';

export const ColorSelectorFormComponent = (props: FormComponentProps) => {
    console.log('ColorSelectorFormComponent', props);

    const handleOnChange = (value: string) => {
        props.onChange?.(value);
    };

    return <FormItemWrapper
        label={props.label}
        explanationText={props.explanationText}
        invalid={props.invalid}
        validationMessage={props.validationMessage}
        markAsRequired={props.required}
        labelIcon={props.tooltip ? 'xp-i-circle' : undefined}
        labelIconTooltip={props.tooltip}
        disabled={props.disabled}>
        <div style={{pointerEvents: props.disabled ? 'none' : 'auto', opacity: props.disabled ? 0.5 : 1}}>
            <HexColorPicker color={props.value} onChange={handleOnChange}/>
        </div>
    </FormItemWrapper>;
};