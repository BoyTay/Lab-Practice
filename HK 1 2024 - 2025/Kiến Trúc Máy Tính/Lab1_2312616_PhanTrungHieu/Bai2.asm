.model small 
.stack 100h
.data   
    a db 'Nhap 1 ki tu: $'
    result db ? 
    b db 13,10,'Ki tu da nhap: $'
.code  
    mov ax, @data
    mov ds,ax
    
    mov ah, 9
    lea dx, a
    int 21h  
    
    mov ah, 1
    int 21h  
    mov result, al
    
    mov ah, 9
    lea dx, b
    int 21h
    
    mov ah, 2
    mov dl, result
    int 21h
    
    mov ah, 4ch
    int 21h
    
    
end



