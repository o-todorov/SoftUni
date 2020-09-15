#pragma once
#ifndef PASTE_TRANSFORM_H
#define PASTE_TRANSFORM_H


class PasteTransform: public TextTransform {
public:
    virtual void invokeOn(std::string& text, int startIndex, int endIndex) override {
        text.replace(text.begin() + startIndex, text.begin() + endIndex,
         CutTransform::clipboard);
    }
};



#endif // !PASTE_TRANSFORM_H
