.model small
.stack 100h
.data
    Char   DB 13,10, "Nhap mot ky tu hoac (ESC) de thoat: $"
    TBKhac DB 13,10, "Ky tu nhap khac chu/so$"
    TBChu  DB 13,10, "Ky tu nhap la chu$"
    TBSo   DB 13,10, "Ky tu nhap la so $"
    newl   DB 13,10,"$"
    
.code 
    mov AX, @data
    mov DS, AX
    
    Lap:
    mov DX, offset Char
    mov AH, 9
    int 21h
    
    mov AH, 1
    int 21h
    
    cmp AL, 27d
    je Thoat      ; Nhap ESC de thoat chuong trinh
    cmp AL, '0'
    jl  Khac
    cmp AL, '9'
    jle So
    cmp AL, 'a'
    jl  Khac
    cmp AL, 'z'
    jle Chu
    cmp AL, 'A'
    jl  Khac
    cmp AL, 'Z'
    jle Chu 
    
    
    Khac: 
        mov DX, offset TBKhac
        mov AH,9
        int 21h
        call NewLine
        jmp Lap
    So:
        mov DX, offset TBSo
        mov AH,9
        int 21h 
        call NewLine
        jmp Lap 
    Chu:
        mov DX, offset TBChu
        mov AH,9
        int 21h
        call NewLine
        jmp Lap
    Thoat:
        mov AH, 4ch
        int 21h
    NewLine:
        mov DX, offset newl
        mov AH, 9
        int 21h
        ret    
            
end
