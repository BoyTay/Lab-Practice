.model small
.stack 100h
.data
    read_char db 10,13,"Hay nhap mot chu thuong (a-z) $"
    str       db 10,13, "Chu hoa tuong ung la: $"
    
.code
    main proc
        mov ax, @data
        mov ds, ax
        
        Nhap_Lai:
        mov dx, offset read_char
        mov ah, 9
        int 21h
    
        mov ah, 8
        int 21h
        mov cl ,al
    
        mov dx, offset str
        mov ah, 9
        int 21h
        
        cmp cl, 'a'
        jl Nhap_Lai  
        cmp cl, 'z'
        jle Chu_Hoa
        
    
        ; Thoat chuong trinh
        mov ah, 4ch
        int 21h
    main endp
    
    Chu_Hoa:
        mov dl, cl
        sub dl, 20h   ; Theo bang ma ASCII thi a = 61h (97d) , A = 41h (65d) 
        mov ah, 2     ; nen ta chuyen a thanh A bang cach tru cho 20h hoac 32d
        int 21h 
    
end
