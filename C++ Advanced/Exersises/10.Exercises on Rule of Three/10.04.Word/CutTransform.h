#pragma once
#ifndef CUT_TRANSFORM_H
#define CUT_TRANSFORM_H


class CutTransform: public TextTransform {
public:
    static std::string clipboard;

    virtual void invokeOn(std::string& text, int startIndex, int endIndex) override {
        clipboard = std::string(text.begin() + startIndex, text.begin() + endIndex);
        text.erase(text.begin()+startIndex,text.begin()+ endIndex);
    }
};

std::string CutTransform::clipboard = "";

#endif // !CUT_TRANSFORM_H