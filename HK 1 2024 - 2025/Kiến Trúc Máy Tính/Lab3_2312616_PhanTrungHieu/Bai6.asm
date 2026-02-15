.model small
.stack 100h
.data
    read_char db "Nhap mot ky tu: $" 
    str1      db 10,13,"Nam ky tu dung truoc: $"
    str2      db 10,13,"nam ky tu dung sau: $"
    char      db ?
.code
    main proc
        mov ax, @data
        mov ds, ax ; Khoi tao thanh ghi DS
        
        mov dx, offset read_char
        mov ah, 9
        int 21h
        
        mov ah, 1  ; Nhap 1 ky tu
        int 21h
        mov char, al
        
        mov cx, 5   ; khoi tao so lan lap (loop)
        
        mov dx, offset str1
        mov ah, 9
        int 21h 
        sub char, 5
        call Dung_Truoc
        
        mov cx, 5
        
        mov dx, offset str2
        mov ah, 9
        int 21h
        inc char
        call Dung_Sau
        
        ; Thoat chuong trinh
        mov ah, 4ch
        int 21h 
           
    main endp
    
    Dung_Truoc: 
        mov dl, char
        inc char
        
        mov ah, 2
        int 21h
        
        loop Dung_Truoc
        
        ret
    Dung_Sau:
        
        mov dl, char
        inc char
        
        mov ah, 2
        int 21h
        
        loop Dung_Truoc
        
        ret
        
        
end