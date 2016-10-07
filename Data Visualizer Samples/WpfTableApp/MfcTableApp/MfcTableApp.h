
// MfcTableApp.h : main header file for the MfcTableApp application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CMfcTableAppApp:
// See MfcTableApp.cpp for the implementation of this class
//

class CMfcTableAppApp : public CWinApp
{
public:
	CMfcTableAppApp();


// Overrides
public:
	virtual BOOL InitInstance();

// Implementation
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CMfcTableAppApp theApp;
