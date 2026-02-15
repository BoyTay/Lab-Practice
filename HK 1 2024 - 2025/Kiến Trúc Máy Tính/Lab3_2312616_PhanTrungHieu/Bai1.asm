.model small
.stack 100h
.data 
     char DB 10,13,"Bay gio la (S)ang, (C)hieu hay (T)oi? $"
     str1 DB 10,13,"Chao Buoi Sang!$"
     str2 DB 10,13,"Chao Buoi Chieu!$"
     str3 DB 10,13,"Chao Buoi Toi!$"
.code
        mov AX, @data
        mov DS, AX      ;khoi tao thanh ghi DS
        
        ReadChar:
        mov DX, OFFSET char    
        mov AH,9
        int 21h
        
        mov AH, 1
        int 21h
        
        cmp AL,'S'
        je Sang
        cmp AL,'s'
        je Sang
        cmp AL,'C'
        je Chieu
        cmp AL,'c'
        je Chieu
        cmp AL,'T'
        je Toi
        cmp AL,'t'
        je Toi
        jmp ReadChar  
        
        Sang: 
            mov DX, OFFSET str1
            mov AH,9
            int 21h
            jmp KetThuc
        Chieu:
            mov DX, OFFSET str2
            mov AH,9
            int 21h
            jmp KetThuc
        Toi: 
            mov DX, OFFSET str3
            mov AH,9
            int 21h
            jmp KetThuc
        KetThuc:
            mov AH, 4ch
            int 21h
    
end