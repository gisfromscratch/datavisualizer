
// MfcTableAppView.h : interface of the CMfcTableAppView class
//

#pragma once


class CMfcTableAppView : public CListView
{
protected: // create from serialization only
	CMfcTableAppView();
	DECLARE_DYNCREATE(CMfcTableAppView)

// Attributes
public:
	CMfcTableAppDoc* GetDocument() const;

// Operations
public:

// Overrides
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual void OnInitialUpdate(); // called first time after construct

// Implementation
public:
	virtual ~CMfcTableAppView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in MfcTableAppView.cpp
inline CMfcTableAppDoc* CMfcTableAppView::GetDocument() const
   { return reinterpret_cast<CMfcTableAppDoc*>(m_pDocument); }
#endif

