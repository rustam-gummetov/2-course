dseg segment
	arr dw 0, 4, 2, 5, 6, 2, 8, 9, 5, 4, '*'
	space db ' ', '$'
dseg ends

cseg segment
assume cs: cseg, ds: dseg
	start:
		mov ax, dseg
		mov ds, ax
		mov cx, 1
		mov si, 0
		
	b0:	cmp cx, 3
		je b1
		cmp arr[si], '*'
		je fin
		add si, 2
		inc cx
		jmp b0
		
	b1: cmp cx, 3
		je b2
	b3:	mov ax, arr[si - 2]
		mov arr[si], ax
		sub si, 2
		dec cx
		cmp cx, 1
		je b4
		jmp b1
	
	b2:	mov dx, arr[si]
		jmp b3
		
	b4: mov arr[si], dx
		add si, 6
		jmp b0
		
	fin:mov si, 0
	b5:	cmp arr[si], '*'
		je pr_end
		mov dx, arr[si]
		or dl, 48
		mov ah, 6
		int 21h
		lea dx, space
		mov ah, 9
		int 21h
		add si, 2
		jmp b5
	pr_end:	mov ax, 04C00h
		int 21h

cseg ends
end start