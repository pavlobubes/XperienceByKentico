import React, { useState } from 'react';
import { ValidationRule, ValidationRuleProps } from '@kentico/xperience-admin-base';

export interface ValueIsBetweenValidationRuleProps extends ValidationRuleProps {
    readonly max: number
    readonly min: number
}

export const ValueIsBetweenValidationRule: ValidationRule<ValueIsBetweenValidationRuleProps, number> = (props, value) => {
    console.log(props);
    const validate = (max: number, min: number) => {
        return !Number.isInteger(value) || (min <= value && value <= max);
    };

    return { isValid: validate(props.max, props.min), errorMessage: props.errorMessage }
};